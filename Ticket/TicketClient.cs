using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel;

using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace Ticket
{
    public class TicketClient
    {
        private User _user;
        private HttpHelper _httpHelper;
        private bool _isLogin;
        private string _paramKey;
        private const int tryCount = 5;
        private VerifyMode mode = VerifyMode.Login;
        private int defaultDataLength;
        private bool isCacheControl = true;

        public bool IsLogin { get { return _isLogin; } private set { _isLogin = value; } }

        public User User { get { return _user; } set { _user = value; } }

        public City[] Cities { get; private set; }

        public Ticket[] Tickets { get; private set; }

        public TicketInfo CurrentTicket { get; private set; }

        public string ParamKey
        {
            get { return _paramKey; }
            set
            {
                _paramKey = value;
                if (_paramKey.Length > 0)
                {
                    ParamValue = TicketUtil.ParamEncrypt(_paramKey, "1111");
                }
            }
        }

        public string ParamValue { get; private set; }

        private string cerPath = AppDomain.CurrentDomain.BaseDirectory + "12306.cer";

        public TicketClient(Encoding encoding)
        {
            _httpHelper = new HttpHelper(encoding, cerPath);
            defaultDataLength = TicketUtil.UrlEncode(default_post_data).Length;
        }
        #region url
        private static string domain = "kyfw.12306.cn";
        private static string host = "https://kyfw.12306.cn/otn/";
        private static string login_init_url = host + "login/init";
        private static string verify_image_url = host + "resources/js/newpasscode/captcha.png";
        private static string login_verify_url = host + "passcodeNew/getPassCodeNew?module={0}&rand=sjrand&0.{1}";
        private static string login_check_url = host + "passcodeNew/checkRandCodeAnsyn";
        private static string login_url = host + "login/loginAysnSuggest";
        private static string login_url2 = host + "login/userLogin";
        private static string login_url3 = host + "index/initMy12306";
        private static string passenger_url = host + "passengers/init";
        private static string passenger_query_url = host + "passengers/query";
        private static string city_url = host + "resources/js/framework/station_name.js?station_version=1.8268";
        private static string query_ticket_url = host + "leftTicket/query?leftTicketDTO.train_date={0}&leftTicketDTO.from_station={1}&leftTicketDTO.to_station={2}&purpose_codes=ADULT";
        private static string delete_passenger_url = host + "passengers/delete";
        private static string add_passenger_url = host + "passengers/add";
        private static string submit_order_request_url = host + "leftTicket/submitOrderRequest";
        private static string init_dc_url = host + "confirmPassenger/initDc";
        private static string check_order_url = host + "confirmPassenger/checkOrderInfo";
        private static string get_queue_count = host + "confirmPassenger/getQueueCount";
        private static string check_user_url = host + "login/checkUser";
        private static string logout_url = host + "login/loginOut";

        private static string default_post_data = "_json_att=";
        private static byte[] default_post_data_bytes = Encoding.Default.GetBytes(default_post_data);
        #endregion

        public void ClearCookies()
        {
            this._httpHelper.ClearCookies();
        }

        public void LoadCities()
        {
            string html = this._httpHelper.GetHtml(city_url);
            string[] cInfo = null;
            Cities = (from s in html.Split('@') where (cInfo = s.Split('|')).Length == 6 select new City() { ShortName = cInfo[0], CnName = cInfo[1], EnId = cInfo[2], Pinyin = cInfo[3], ShortPinyin = cInfo[4], Id = cInfo[5] }).ToArray();
            OnLoadCitiesCompleted(new CityEventArgs(Cities));
        }

        public TicketResult QueryTicket(string date, string from, string to)
        {
            string url = string.Format(query_ticket_url, date, from, to);
            string html = this._httpHelper.GetHtml(url);
            var TicketResult = JsonConvert.DeserializeObject<TicketResult>(html);
            Tickets = TicketResult != null ? TicketResult.data : null;
            return TicketResult;
        }

        public void InitLogin()
        {
            string html = string.Empty;
            while (true)
            {
                html = _httpHelper.GetHtml(login_init_url, GetInitHeaders(_httpHelper.GetCookiesString(login_init_url)));
                if (!string.IsNullOrEmpty(html))
                {
                    break;
                }
            }

            RefreshDynamicKey(html);
        }

        private void RefreshDynamicKey(string html)
        {
            var dynamicUrl = GetDynamicJsUrl(html);
            ParamKey = GetDynamicKey(dynamicUrl);
            var jsUrl = GetDynamicUrl(html);
        }

        public void RefreshVerify(VerifyMode mode)
        {
            this.mode = mode;

            string url = string.Format(login_verify_url, GetLoginMode(mode), DateTime.Now.Ticks.ToString());
            try
            {
                var image = this._httpHelper.GetImage(url, GetVerifyImageHeaders(this._httpHelper.GetCookiesString(login_init_url)));
                var e = new VerifyEventArgs(mode, image);
                OnRefreshVerifyCompleted(e);
            }
            catch (Exception e)
            {
                //获取验证码失败
            }
        }

        public bool CheckVerify(string code, string token)
        {
            string data = GetVerifyData(code, token);
            byte[] dataBytes = Encoding.Default.GetBytes(data);
            var headers = GetCheckVerifyHeaders(dataBytes.Length, this._httpHelper.GetCookiesString(login_init_url));
            string html = this._httpHelper.PostHtml(login_check_url, data, login_init_url);
            var verifyResult = JsonConvert.DeserializeObject<VerifyResult>(html);
            return verifyResult.data != null && verifyResult.data.result == "1";
        }

        public void CheckLogin(string uname, string upwd, string code)
        {
            LoginEventArgs loginEventArgs = null;
            if (CheckVerify(code, string.Empty))
            {
                this.User = new User(uname, upwd);
                string data = string.Format("loginUserDTO.user_name={0}&userDTO.password={1}&randCode={2}&{3}={4}&myversion=undefined", uname, upwd, TicketUtil.UrlEncode(code), ParamKey, TicketUtil.UrlEncode(ParamValue));
                byte[] dataBytes = Encoding.Default.GetBytes(data);
                var headers = GetLoginHeaders(dataBytes.Length.ToString(), _httpHelper.GetCookiesString(login_init_url));
                string html = _httpHelper.PostHtml(login_url, headers, dataBytes);
                var loginResult = JsonConvert.DeserializeObject<LoginResult>(html);

                if (loginResult.data != null && loginResult.data.loginCheck == "Y")
                {
                    this.User.NickName = GetNickName(_httpHelper.PostHtml(login_url2, "_json_att="));
                    _httpHelper.GetHtml(login_url3);
                    BeginGetPassengers();
                    this.IsLogin = true;
                    loginEventArgs = new LoginEventArgs(0, "登录成功!");
                }
                else
                {
                    var msg = (loginResult.messages != null && loginResult.messages.Length > 0) ? loginResult.messages[0] : "未知错误!";
                    loginEventArgs = new LoginEventArgs(-1, msg);
                }
            }
            else
            {
                loginEventArgs = new LoginEventArgs(-1, "FALSE");
            }

            OnLoginCompleted(loginEventArgs);
        }

        public void Reservation(string trainDate, string secret, string fromStationName, string toStationName)
        {
            if (!IsLogin)
                return;

            string html = _httpHelper.PostHtml(check_user_url, GetCheckUserHeaders(), default_post_data_bytes);

            string requestOrderData = string.Format("{0}={1}&myversion=undefined&secretStr={2}&train_date={3}&back_train_date={4}&tour_flag=dc&purpose_codes=ADULT&query_from_station_name={5}&query_to_station_name={6}&undefined", ParamKey, TicketUtil.UrlEncode(ParamValue), secret, TicketUtil.ToLongDate(trainDate), DateTime.Now.ToString("yyyy-MM-dd"), fromStationName, toStationName);
            var requestOrderBytes = Encoding.Default.GetBytes(requestOrderData);
            html = _httpHelper.PostHtml(submit_order_request_url, GetOrderRequestHeaders(requestOrderBytes.Length), requestOrderBytes);

            html = _httpHelper.PostHtml(init_dc_url, GetInitDcHeaders(), default_post_data_bytes);
            RefreshDynamicKey(html);

            CurrentTicket = JsonConvert.DeserializeObject<TicketInfo>(ticketInfoRegex.Match(html).Groups["value"].Value);
            OnRequestOrderCompleted(new RequestOrderEventArgs(CurrentTicket));
        }

        private Dictionary<string, string> GetInitHeaders(string cookie)
        {
            return GetGetHeaders("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8", host, cookie);
        }

        private Dictionary<string, string> GetVerifyImageHeaders(string cookie)
        {
            return GetGetHeaders("mage/webp,*/*;q=0.8", login_init_url, cookie);
        }

        private Dictionary<string, string> GetCheckVerifyHeaders(int cLength, string cookie)
        {
            return GetPostHeaders("*/*", cLength, cookie);
        }

        private Dictionary<string, string> GetDynamicHeaders(string cookie)
        {
            return GetGetHeaders("*/*", login_init_url, cookie);
        }

        private Dictionary<string, string> GetLoginHeaders(string cLength, string cookie)
        {
            return GetPostHeaders("*/*", defaultDataLength, _httpHelper.GetCookiesString(login_init_url));
        }

        private Dictionary<string, string> GetCheckUserHeaders()
        {
            return GetPostHeaders("*/*", defaultDataLength, _httpHelper.GetCookiesString(login_init_url), "0");
        }

        private Dictionary<string, string> GetOrderRequestHeaders(int cLength)
        {
            return GetPostHeaders("*/*", cLength, _httpHelper.GetCookiesString(login_init_url));
        }

        private Dictionary<string, string> GetInitDcHeaders()
        {
            return GetPostHeaders("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8", defaultDataLength, _httpHelper.GetCookiesString(login_init_url));
        }

        private Dictionary<string, string> GetCheckOrderHeaders(int cLength)
        {
            return GetPostHeaders("application/json, text/javascript, */*; q=0.01", cLength, _httpHelper.GetCookiesString(login_init_url));
        }

        private Dictionary<string, string> GetGetHeaders(string accept, string referer, string cookie, bool isCacheControl = false)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Accept", accept);
            headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            if (isCacheControl)
            {
                headers.Add("Cache-Control", "max-age=0");
            }
            headers.Add("Connection", "keep-alive");
            if (!string.IsNullOrEmpty(cookie))
            {
                headers.Add("Cookie", cookie);
            }
            headers.Add("Host", "kyfw.12306.cn");
            headers.Add("Referer", referer);
            headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36");

            return headers;
        }

        private Dictionary<string, string> GetPostHeaders(string accept, int cLength, string cookie, string modified = "")
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Accept", accept);
            headers.Add("Accept-Encoding", "gzip, deflate");
            headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            headers.Add("Connection", "keep-alive");
            headers.Add("Content-Length", cLength.ToString());
            headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            headers.Add("Cookie", cookie);
            headers.Add("Host", "kyfw.12306.cn");
            if (!string.IsNullOrEmpty(modified))
            {
                headers.Add("If-Modified-Sinc", modified);
            }
            headers.Add("Origin", "https://kyfw.12306.cn");
            headers.Add("Referer", login_init_url);
            headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36");
            headers.Add("X-Requested-With", "XMLHttpRequest");
            return headers;
        }


        private void BeginGetPassengers()
        {
            Task t = new Task(() =>
            {
                GetPassengers();
            });
            t.ContinueWith((task) =>
            {
                //处理异常
            });
            t.Start();
        }

        public void GetPassengers()
        {
            this.User.Passengers.Clear();

            int totalPage = 1;
            for (var i = 0; i < totalPage; i++)
            {
                string data = string.Format("pageIndex={0}&pageSize=10", (i + 1));
                string html = this._httpHelper.PostHtml(passenger_query_url, data);
                PassengerResult result = JsonConvert.DeserializeObject<PassengerResult>(html);
                if (result.data != null && result.data.flag)
                {
                    this.User.Passengers.AddRange(result.data.datas);
                    totalPage = result.data.pageTotal;
                }
            }

            OnLoadPassengerCompleted(new PassengerEventArgs(OperCommand.Get, this.User.Passengers.ToArray()));
        }

        public bool AddPassenger(string name, string typeCode, string no, string mobile, string phone, string email, string address, string postalcode, string passengerType)
        {
            string sex = TicketUtil.GetSex(no);

            string data = string.Format("passenger_name={0}&sex_code={9}&_birthDate=&country_code=CN&passenger_id_type_code={1}&passenger_id_no={2}&mobile_no={3}&phone_no={4}&email={5}&address={6}&postalcode={7}&passenger_type={8}&studentInfoDTO.province_code=11&studentInfoDTO.school_code=&studentInfoDTO.school_name=%E7%AE%80%E7%A0%81%2F%E6%B1%89%E5%AD%97&studentInfoDTO.department=&studentInfoDTO.school_class=&studentInfoDTO.student_no=&studentInfoDTO.school_system=1&studentInfoDTO.enter_year=2015&studentInfoDTO.preference_card_no=&studentInfoDTO.preference_from_station_name=&studentInfoDTO.preference_from_station_code=&studentInfoDTO.preference_to_station_name=&studentInfoDTO.preference_to_station_code=", name, typeCode, no, mobile, phone, email, address, postalcode, passengerType, sex);
            string html = this._httpHelper.PostHtml(add_passenger_url, data);
            bool isSuccess = false;
            if (isSuccess)
            {
                this.User.AddPassenger(new Passenger() { passenger_id_no = no });
            }
            return isSuccess;
        }

        public bool DeletePassenger(Passenger passenger)
        {
            string data = string.Format("passenger_name={0}&passenger_id_type_code={1}&passenger_id_no={2}&isUserSelf={3}", passenger.passenger_name, passenger.passenger_id_type_code, passenger.passenger_id_no, passenger.isUserSelf);
            string html = this._httpHelper.PostHtml(delete_passenger_url, data);
            bool isSuccess = false;
            if (isSuccess)
            {
                this.User.RemovePassenger(passenger.passenger_id_no);
            }
            return isSuccess;
        }

        public void Logout()
        {
            var html = this._httpHelper.GetHtml(logout_url);
            this.IsLogin = false;
        }

        private Regex dynamicRegex = new Regex("src=\"/otn/(?<value>dynamicJs/\\w+)\"");
        private Regex dynamicRegex2 = new Regex("/otn/(?<value>dynamicJs/\\w+)");
        private Regex paramRegex = new Regex("gc[(][)][{]var \\w+='(?<value>\\w+)';");
        private Regex pageRegex = new Regex("var totlePage = (?<value>\\d+);");
        private Regex unameRegex = new Regex("user_name='(?<value>.+?)';");
        private Regex ticketInfoRegex = new Regex("ticketInfoForPassengerForm=(?<value>[\\w\\W]+?);");

        private string GetDynamicJsUrl(string html)
        {
            return string.Format("{0}{1}", host, dynamicRegex.Match(html).Groups["value"].Value.TrimStart('/'));
        }

        private string GetDynamicKey(string url)
        {
            string cookie = _httpHelper.GetCookiesString(login_init_url);
            var html = _httpHelper.GetHtml(url, GetDynamicHeaders(cookie));
            return paramRegex.Match(html).Groups["value"].Value;
        }

        private string GetDynamicUrl(string html)
        {
            return string.Format("{0}{1}", host, dynamicRegex2.Match(html).Groups["value"].Value.TrimStart('/'));
        }

        private string GetNickName(string html)
        {
            return System.Web.HttpUtility.UrlDecode(unameRegex.Match(html).Groups["value"].Value.Replace("\\u", "%u"));
        }

        public event EventHandler<CityEventArgs> LoadCitiesCompleted;
        public event EventHandler<VerifyEventArgs> RefreshVerifyCompleted;
        public event EventHandler<VerifyResultEventArgs> CheckVerifyCompleted;
        public event EventHandler<LoginEventArgs> LoginCompleted;
        public event EventHandler<PassengerEventArgs> LoadPassengerCompleted;
        public event EventHandler<PassengerEventArgs> OpertionPassengerCompleted;
        public event EventHandler<RequestOrderEventArgs> RequestOrderCompleted;
        public event EventHandler<SessionEventArgs> KeepLive;

        private void OnLoadCitiesCompleted(CityEventArgs e)
        {
            if (LoadCitiesCompleted != null)
            {
                LoadCitiesCompleted(this, e);
            }
        }

        private void OnRefreshVerifyCompleted(VerifyEventArgs e)
        {
            if (RefreshVerifyCompleted != null)
            {
                RefreshVerifyCompleted(this, e);
            }
        }

        private void OnCheckVerifyCompleted(VerifyResultEventArgs e)
        {
            if (CheckVerifyCompleted != null)
            {
                CheckVerifyCompleted(this, e);
            }
        }

        private void OnLoginCompleted(LoginEventArgs e)
        {
            if (LoginCompleted != null)
            {
                LoginCompleted(this, e);
            }
        }

        private void OnLoadPassengerCompleted(PassengerEventArgs e)
        {
            if (LoadPassengerCompleted != null)
            {
                LoadPassengerCompleted(this, e);
            }
        }

        private void OnOpertionPassengerCompleted(PassengerEventArgs e)
        {
            if (OpertionPassengerCompleted != null)
            {
                OpertionPassengerCompleted(this, e);
            }
        }

        private void OnRequestOrderCompleted(RequestOrderEventArgs e)
        {
            if (RequestOrderCompleted != null)
            {
                RequestOrderCompleted(this, e);
            }
        }

        private void OnKeepLive(SessionEventArgs e)
        {
            if (KeepLive != null)
            {
                KeepLive(this, e);
            }

            if (e.State != 0)
            {
                RefreshVerify(VerifyMode.VerifyError);
            }
        }

        private string GetLoginMode(VerifyMode verifyMode)
        {
            string mode = string.Empty;

            switch (verifyMode)
            {
                case VerifyMode.Login:
                case VerifyMode.VerifyError:
                    mode = "login";
                    break;
                case VerifyMode.Passenger:
                    mode = "passenger";
                    break;
            }

            return mode;
        }

        private string GetVerifyMode(VerifyMode verifyMode)
        {
            string mode = string.Empty;
            switch (verifyMode)
            {
                case VerifyMode.Login:
                case VerifyMode.VerifyError:
                    mode = "sjrand";
                    break;
                case VerifyMode.Passenger:
                    mode = "randp";
                    break;
            }

            return mode;
        }

        private string GetVerifyData(string code, string token)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetFormKeyValue("randCode", code));
            sb.Append("&");
            sb.Append(GetFormKeyValue("rand", GetVerifyMode(mode)));
            if (mode == VerifyMode.Passenger)
            {
                sb.Append("&");
                sb.Append(GetFormKeyValue("_json_att", string.Empty));
                sb.Append("&");
                sb.Append(GetFormKeyValue("REPEAT_SUBMIT_TOKEN=", token));
            }

            return sb.ToString();
        }

        private string GetFormKeyValue(string name, string value)
        {
            return string.Format("{0}={1}", name, TicketUtil.UrlEncode(value));
        }
    }

    public class Result
    {
        public string validateMessagesShowId { get; set; }

        public string status { get; set; }

        public string httpstatus { get; set; }

        public string[] messages { get; set; }
    }

    public class VerifyResult : Result
    {
        public VerifyData data { get; set; }
    }

    public class VerifyData
    {
        public string result { get; set; }

        public string msg { get; set; }
    }

    public class LoginResult : Result
    {
        public LoginData data { get; set; }
    }

    public class LoginData
    {
        public string loginCheck { get; set; }
    }

    public class TicketResult : Result
    {
        public Ticket[] data { get; set; }
    }

    public class Ticket
    {
        public NewDto queryLeftNewDTO { get; set; }

        public string secretStr { get; set; }

        public string buttonTextInfo { get; set; }

        public override string ToString()
        {
            return string.Format("<tr><td><a name='station' href='javascript:void(0);'>{0}</a></td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td><td>{11}</td><td>{12}</td><td>{13}</td><td>{14}</td><td><a name='order' id='{16}' href='javascript:void(0);'>{15}</a></td></tr>", queryLeftNewDTO.station_train_code, queryLeftNewDTO.from_station_name + "</br>" + queryLeftNewDTO.start_time, queryLeftNewDTO.to_station_name + "</br>" + queryLeftNewDTO.arrive_time, queryLeftNewDTO.lishi, queryLeftNewDTO.swz_num, queryLeftNewDTO.tz_num, queryLeftNewDTO.zy_num, queryLeftNewDTO.ze_num, queryLeftNewDTO.gr_num, queryLeftNewDTO.rw_num, queryLeftNewDTO.yw_num, queryLeftNewDTO.rz_num, queryLeftNewDTO.yz_num, queryLeftNewDTO.wz_num, queryLeftNewDTO.qt_num, buttonTextInfo, this.secretStr);
        }
    }

    public class NewDto
    {
        public string train_no { get; set; }

        public string station_train_code { get; set; }

        public string start_station_telecode { get; set; }

        public string start_station_name { get; set; }

        public string end_station_telecode { get; set; }

        public string end_station_name { get; set; }

        public string from_station_telecode { get; set; }

        public string from_station_name { get; set; }

        public string to_station_telecode { get; set; }

        public string to_station_name { get; set; }

        public string start_time { get; set; }

        public string arrive_time { get; set; }

        public string day_difference { get; set; }

        public string train_class_name { get; set; }

        public string lishi { get; set; }

        public string canWebBuy { get; set; }

        public string lishiValue { get; set; }

        public string yp_info { get; set; }

        public string control_train_day { get; set; }

        public string start_train_date { get; set; }

        public string seat_feature { get; set; }

        public string yp_ex { get; set; }

        public string train_seat_feature { get; set; }

        public string seat_types { get; set; }

        public string location_code { get; set; }

        public string from_station_no { get; set; }

        public string to_station_no { get; set; }

        public string control_day { get; set; }

        public string sale_time { get; set; }

        public string is_support_card { get; set; }

        public string gg_num { get; set; }

        public string gr_num { get; set; }

        public string qt_num { get; set; }

        public string rw_num { get; set; }

        public string rz_num { get; set; }

        public string tz_num { get; set; }

        public string wz_num { get; set; }

        public string yb_num { get; set; }

        public string yw_num { get; set; }

        public string yz_num { get; set; }

        public string ze_num { get; set; }

        public string zy_num { get; set; }

        public string swz_num { get; set; }
    }

    public class TicketInfo
    {
        public CardType2[] cardTypes { get; set; }

        public string isAsync { get; set; }

        public string key_check_isChange { get; set; }

        public string[] leftDetails { get; set; }

        public string leftTicketStr { get; set; }

        public LimitBuySeatTicketDTO limitBuySeatTicketDTO { get; set; }

        public string maxTicketNum { get; set; }

        public OrderRequestDTO orderRequestDTO { get; set; }

        public string purpose_codes { get; set; }

        public QueryLeftNewDetailDTO queryLeftNewDetailDTO { get; set; }

        public QueryLeftTicketRequestDTO queryLeftTicketRequestDTO { get; set; }

        public string tour_flag { get; set; }

        public string train_location { get; set; }
    }

    public class CardType2
    {
        public string end_station_name { get; set; }

        public string end_time { get; set; }

        public string id { get; set; }

        public string start_station_name { get; set; }

        public string start_time { get; set; }

        public string value { get; set; }
    }

    public class LimitBuySeatTicketDTO
    {
        public CardType2[] seat_type_codes { get; set; }

        public Dictionary<int, CardType2[]> ticket_seat_codeMap { get; set; }

        public CardType2[] ticket_type_codes { get; set; }
    }

    public class OrderRequestDTO
    {
        public int adult_num { get; set; }

        public string apply_order_no { get; set; }

        public string bed_level_order_num { get; set; }

        public string bureau_code { get; set; }

        public string cancel_flag { get; set; }

        public string card_num { get; set; }

        public int child_num { get; set; }

        public int disability_num { get; set; }

        public Time end_time { get; set; }

        public string from_station_name { get; set; }

        public string from_station_telecode { get; set; }

        public string get_ticket_pass { get; set; }

        public string id_mode { get; set; }

        public string order_date { get; set; }

        public string reserve_flag { get; set; }

        public string seat_detail_type_code { get; set; }

        public string seat_type_code { get; set; }

        public string sequence_no { get; set; }

        public Time start_time { get; set; }

        public string start_time_str { get; set; }

        public string station_train_code { get; set; }

        public string student_num { get; set; }

        public string ticket_num { get; set; }

        public string ticket_type_order_num { get; set; }

        public string to_station_name { get; set; }

        public string to_station_telecode { get; set; }

        public string tour_flag { get; set; }

        public string trainCodeText { get; set; }

        public Time train_date { get; set; }

        public string train_date_str { get; set; }

        public string train_location { get; set; }

        public string train_no { get; set; }

        public string train_order { get; set; }
    }

    public class QueryLeftNewDetailDTO
    {
        public string BXRZ_num { get; set; }
        public string BXRZ_price { get; set; }
        public string BXYW_num { get; set; }
        public string BXYW_price { get; set; }
        public string EDRZ_num { get; set; }
        public string EDRZ_price { get; set; }
        public string EDSR_num { get; set; }
        public string EDSR_price { get; set; }
        public string ERRB_num { get; set; }
        public string ERRB_price { get; set; }
        public string GG_num { get; set; }
        public string GG_price { get; set; }
        public string GR_num { get; set; }
        public string GR_price { get; set; }
        public string HBRW_num { get; set; }
        public string HBRW_price { get; set; }
        public string HBRZ_num { get; set; }
        public string HBRZ_price { get; set; }
        public string HBYW_num { get; set; }
        public string HBYW_price { get; set; }
        public string HBYZ_num { get; set; }
        public string HBYZ_price { get; set; }
        public string RW_num { get; set; }
        public string RW_price { get; set; }
        public string RZ_num { get; set; }
        public string RZ_price { get; set; }
        public string SRRB_num { get; set; }
        public string SRRB_price { get; set; }
        public string SWZ_num { get; set; }
        public string SWZ_price { get; set; }
        public string TDRZ_num { get; set; }
        public string TDRZ_price { get; set; }
        public string TZ_num { get; set; }
        public string TZ_price { get; set; }
        public string WZ_num { get; set; }
        public string WZ_price { get; set; }
        public string WZ_seat_type_code { get; set; }
        public string YB_num { get; set; }
        public string YB_price { get; set; }
        public string YDRZ_num { get; set; }
        public string YDRZ_price { get; set; }
        public string YDSR_num { get; set; }
        public string YDSR_price { get; set; }
        public string YRRB_num { get; set; }
        public string YRRB_price { get; set; }
        public string YW_num { get; set; }
        public string YW_price { get; set; }
        public string YYRW_num { get; set; }
        public string YYRW_price { get; set; }
        public string YZ_num { get; set; }
        public string YZ_price { get; set; }
        public string ZE_num { get; set; }
        public string ZE_price { get; set; }
        public string ZY_num { get; set; }
        public string ZY_price { get; set; }
        public string arrive_time { get; set; }
        public string control_train_day { get; set; }
        public string day_difference { get; set; }
        public string end_station_name { get; set; }
        public string end_station_telecode { get; set; }
        public string from_station_name { get; set; }
        public string from_station_telecode { get; set; }
        public string is_support_card { get; set; }
        public string lishi { get; set; }
        public string seat_feature { get; set; }
        public string start_station_name { get; set; }
        public string start_station_telecode { get; set; }
        public string start_time { get; set; }
        public string start_train_date { get; set; }
        public string station_train_code { get; set; }
        public string to_station_name { get; set; }
        public string to_station_telecode { get; set; }
        public string train_class_name { get; set; }
        public string train_no { get; set; }
        public string train_seat_feature { get; set; }
        public string yp_ex { get; set; }
    }

    public class QueryLeftTicketRequestDTO
    {
        public string arrive_time { get; set; }
        public string bigger20 { get; set; }
        public string from_station { get; set; }
        public string from_station_name { get; set; }
        public string from_station_no { get; set; }
        public string lishi { get; set; }
        public string login_id { get; set; }
        public string login_mode { get; set; }
        public string login_site { get; set; }
        public string purpose_codes { get; set; }
        public string query_type { get; set; }
        public string seatTypeAndNum { get; set; }
        public string seat_types { get; set; }
        public string start_time { get; set; }
        public string start_time_begin { get; set; }
        public string start_time_end { get; set; }
        public string station_train_code { get; set; }
        public string to_station { get; set; }
        public string to_station_name { get; set; }
        public string to_station_no { get; set; }
        public string train_date { get; set; }
        public string train_flag { get; set; }
        public string train_headers { get; set; }
        public string train_no { get; set; }
        public bool useMasterPool { get; set; }
        public bool useWB10LimitTime { get; set; }
        public bool usingGemfireCache { get; set; }
        public string ypInfoDetail { get; set; }

        public string ToHtmlString()
        {
            string longDate = TicketUtil.ToLongDate(this.train_date);
            string date = string.Format("{0}({1})", longDate, TicketUtil.ToCnWeek(Convert.ToDateTime(longDate)));
            return string.Format("<strong>{0}</strong> <strong>{1}</strong>次 <strong>{2}</strong>({3}开)→<strong>{4}</strong>({5}到)", date, station_train_code, from_station_name, start_time, to_station_name, arrive_time);
        }
    }

    public class Time
    {
        public int date { get; set; }

        public int day { get; set; }

        public int hours { get; set; }

        public int minutes { get; set; }

        public int month { get; set; }

        public int seconds { get; set; }

        public int time { get; set; }

        public int timezoneOffset { get; set; }

        public int year { get; set; }
    }

    public class OrderRequestInfo
    {

    }

    public class PassengerResult : Result
    {
        public PassengerData data { get; set; }
    }

    //"flag":true,"pageTotal":3
    public class PassengerData
    {
        public Passenger[] datas { get; set; }

        public bool flag { get; set; }

        public int pageTotal { get; set; }
    }

    public class Passenger
    {
        public string code { get; set; }

        public string passenger_name { get; set; }

        public string sex_code { get; set; }

        public string born_date { get; set; }

        public string country_code { get; set; }

        public string passenger_id_type_code { get; set; }

        public string passenger_id_type_name { get; set; }

        public string passenger_id_no { get; set; }

        public string passenger_type_name { get; set; }

        public string passenger_type { get; set; }

        public string passenger_flag { get; set; }

        public string mobile_no { get; set; }

        public string phone_no { get; set; }

        public string email { get; set; }

        public string address { get; set; }

        public string postalcode { get; set; }

        public string first_letter { get; set; }

        public string recordCount { get; set; }

        public string isUserSelf { get; set; }

        private string _total_times;
        public string total_times
        {
            get { return _total_times; }
            set
            {
                _total_times = value;
                if (this.passenger_id_type_code == "2")
                {
                    passenger_state = "未通过";
                }
                else
                {
                    switch (_total_times)
                    {
                        case "95":
                        case "97":
                            passenger_state = "已通过";
                            break;
                        case "93":
                        case "99":
                            if (this.passenger_id_type_code == "1")
                            {
                                passenger_state = "已通过";
                            }
                            else
                            {
                                passenger_state = "预通过";
                            }
                            break;
                        case "94":
                        case "96":
                            passenger_state = "未通过";
                            break;
                        case "91":
                            passenger_state = "请报验";
                            break;
                        case "92":
                        case "98":
                            if (passenger_id_type_code == "B" || passenger_id_type_code == "C" || passenger_id_type_code == "G")
                            {
                                passenger_state = "请报验";
                            }
                            else
                            {
                                passenger_state = "待核验";
                            }
                            break;
                    }
                }
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public string passenger_state { get; private set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}", passenger_name, passenger_id_type_name, passenger_id_no, mobile_no, passenger_type_name);
        }

        public string PassengerToHtmlString(int index, string seat, string card)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr>");
            sb.Append(string.Format("<td>第{0}位</td>", index));
            sb.Append(string.Format("<td>{0}</td>", seat));
            sb.Append(string.Format("<td>{0}</td>", card));
            sb.Append(string.Format("<td>{0}</td>", passenger_name));
            sb.Append(string.Format("<td>{0}</td>", passenger_id_type_name));
            sb.Append(string.Format("<td>{0}</td>", passenger_id_no));
            sb.Append(string.Format("<td>{0}</td>", mobile_no));
            sb.Append("</tr>");
            return sb.ToString();
        }
    }

    public class City
    {
        public string ShortName { get; set; }

        public string CnName { get; set; }

        public string EnId { get; set; }

        public string Pinyin { get; set; }

        public string ShortPinyin { get; set; }

        public string Id { get; set; }
    }

    public enum CardType : int
    {
        [Description("二代身份证")]
        二代身份证 = 1,
        [Description("港澳通行证")]
        港澳通行证 = 2,
        [Description("台湾通行证")]
        台湾通行证 = 3,
        [Description("护照")]
        护照 = 4
    }

    public enum PassengerType : int
    {
        [Description("成人票")]
        成人票 = 1,
        [Description("儿童票")]
        儿童票 = 2,
        [Description("学生票")]
        学生票 = 3,
        [Description("残军票")]
        残军票 = 4
    }
}
