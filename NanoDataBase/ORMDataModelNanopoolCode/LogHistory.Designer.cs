﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace NanoDataBase.Nanopool
{

    public partial class LogHistory : XPLiteObject
    {
        long fId;
        [Key(true)]
        public long Id
        {
            get { return fId; }
            set { SetPropertyValue<long>("Id", ref fId, value); }
        }
        string fMessage;
        [Size(255)]
        [DevExpress.Xpo.DisplayName(@"Сообщение")]
        public string Message
        {
            get { return fMessage; }
            set { SetPropertyValue<string>("Message", ref fMessage, value); }
        }
        string fDescription;
        [Size(SizeAttribute.Unlimited)]
        [DevExpress.Xpo.DisplayName(@"Описание")]
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>("Description", ref fDescription, value); }
        }
        DateTime fDateLog;
        [DevExpress.Xpo.DisplayName(@"Время логирования")]
        public DateTime DateLog
        {
            get { return fDateLog; }
            set { SetPropertyValue<DateTime>("DateLog", ref fDateLog, value); }
        }
        int fMessageType;
        [DevExpress.Xpo.DisplayName(@"Тип сообщения")]
        public int MessageType
        {
            get { return fMessageType; }
            set { SetPropertyValue<int>("MessageType", ref fMessageType, value); }
        }
    }

}