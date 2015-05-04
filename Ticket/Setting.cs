using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ticket
{
    public class Setting
    {
        private static Setting setting = null;
        private static string setting_path = TicketUtil.base_path + "setting.xml";

        public static Setting GetInstance()
        {
            if (setting == null)
            {
                setting = XmlHelper.DeserilizeAnObject(typeof(Setting), setting_path) as Setting;
            }

            if (setting == null)
            {
                setting = new Setting();
            }

            return setting;
        }

        private Setting()
        {
            PlaySound = new PlaySound();
            PlaySoundAfterQuery = new PlaySound();
            PlaySoundAfterOrder = new PlaySound();
            QueryOption = new QueryOption();
            Proxy = new Proxy();
            IM = new IM();
            Users = new List<User>();
        }

        public bool ShowAgreement2 { get; set; }

        public int LoginInterval2 { get; set; }

        public int QueryInterval3 { get; set; }

        public bool EnabledProxy { get; set; }

        public bool EnabledLog { get; set; }

        public bool AutoSubmitOrderRequest { get; set; }

        public bool SavePassengers2 { get; set; }

        public PlaySound PlaySound { get; set; }

        public PlaySound PlaySoundAfterQuery { get; set; }

        public PlaySound PlaySoundAfterOrder { get; set; }

        public bool UseKeyMode { get; set; }

        public bool ShowNetError { get; set; }

        public bool AutoOL { get; set; }

        public bool AutoSyncTime { get; set; }

        public bool SendOrderDetails { get; set; }

        public string MailTo { get; set; }

        public bool NotEngoughContinue { get; set; }

        public string ADSLName { get; set; }

        public string ADSLConnectURL { get; set; }

        public string ADSLDisconnectURL { get; set; }

        public string ADSLUsername { get; set; }

        public string ADSLPassword { get; set; }

        public bool ReconnectEnabled { get; set; }

        public int LastNewsId { get; set; }

        private QueryOption queryOption;

        public QueryOption QueryOption
        {
            get { return queryOption; }
            set
            {
                queryOption = value;
            }
        }

        private Proxy proxy;
        public Proxy Proxy
        {
            get { return proxy; }
            set
            {
                proxy = value;
            }
        }

        private IM im;
        public IM IM
        {
            get { return im; }
            set
            {
                im = value;
            }
        }

        private List<User> users;

        public List<User> Users
        {
            get { return users; }
            set
            {
                users = value;
            }
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        public void Save()
        {
            XmlHelper.SerilizeAnObject(this, setting_path);
        }
    }

    public class PlaySound
    {
        public PlaySound()
        {
            Enabled = UseDefault = true;
        }

        public bool Enabled { get; set; }

        public bool UseDefault { get; set; }

        public string CustomFile { get; set; }
    }

    public class QueryOption
    {
        public QueryOption()
        {
            StartTime = "00:00--24:00";
            Trains = "1,1,1,2,1,3,1,4,1,5,1,6";
            Seats = "1,1,1,2,1,3,1,4,1,5,1,6,1,7,1,8,1,9,1,10";
        }

        public string FromStation { get; set; }

        public string ToStation { get; set; }

        public string StartTime { get; set; }

        public DateTime StartTimeBegin { get; set; }

        public DateTime StartTimeEnd { get; set; }

        public string IncludeStudent { get; set; }

        public bool IsTrainsFirst { get; set; }

        public string Trains { get; set; }

        public string Seats { get; set; }
    }

    public class Proxy
    {
        public string IP { get; set; }

        public uint Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class IM
    {
        public string FontName { get; set; }

        public string FontColor { get; set; }

        public int FontSize { get; set; }

        public bool FontBold { get; set; }

        public bool FontItalic { get; set; }

        public bool FontUnderline { get; set; }
    }
}
