using System;
using System.ComponentModel;
using MailSender.lib.Entityes.Base;

namespace MailSender.lib.Entityes
{
    public class Recipient : Human, IDataErrorInfo
    {
        public override string Name
        {
            get => base.Name;
            set
            {
                if(value == null)
                    throw new ArgumentNullException(nameof(value));
                base.Name = value;
            }
        }

        string IDataErrorInfo.Error => "";

        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {
                    case nameof(Id):
                        if (Id < 0) return "Идентификатор не может быть меньше 0";
                        if (Id == 0) return "Идентификатор должен быть больше 0!";

                        break;

                    case nameof(Name):
                        if (Name == null) return "Имя не может быть пустой ссылкой";
                        if (Name == "") return "Имя не может быть пустой строкой";
                        if (Name.Length < 3) return "Имя не может быть меньше 3 символов";
                        break;

                    case nameof(EmailAddress):
                        if (EmailAddress == null) return "Электронный адрес не может быть пустой ссылкой";
                        if (EmailAddress == "") return "Электронный адрес не может быть пустой строкой";
                        if (EmailAddress.Length < 5) return "Электронный адрес не может быть меньше 5 символов";

                        break;
                }

                return "";
            }
        }
    }
}