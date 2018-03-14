using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Data.Browsing;

namespace NanoDataBase.Nanopool
{

    public partial class LogHistory
    {
        public LogHistory(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        public MessageTypeEnum EnumMessageType
        {
            get { return (MessageTypeEnum) MessageType; }
            set { MessageType = (int) value; }
        }

        public override string ToString()
        {
            return $"{Message} ({MessageTypeDescription()})";
        }

        private MessageTypeEnum MessageTypeDescription()
        {
            //typeof(MessageTypeEnum).get
            return EnumMessageType;
        }
    }

    /// <summary>
    /// тип сообщения. по умолчанию - 0
    /// </summary>
    public enum MessageTypeEnum
    {
        [Description("Сообщение")]
        Message = 0,
        [Description("Информация")]
        Information = 1,
        [Description("Предупруждение")]
        Warning = 2,
        [Description("Ошибка")]
        Error = 3
    }

}
