using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KozaDisk
{
    public class User
    {
        protected string username = null;

        protected string full_name = "";
        protected string full_name_genitive = "";
        protected string abbreviation = "";
        protected string abbreviation_genitive = "";
        protected string subordination = "";
        protected string subordination_genitive = "";
        protected string unit = "";
        protected string place = "";
        protected string code = "";
        protected string bank = "";
        protected string legal_address = "";
        protected string chief_name = "";
        protected string chief_name_genitive = "";
        protected string chief_surname = "";
        protected string chief_surname_dative = "";
        protected string chief_initials = "";
        protected string chief_position = "";
        protected string chief_position_dative = "";
        protected string chief_position_lower = "";
        protected string position_cadre = "";
        protected string position_cadre_genitive = "";
        protected string initials_cadre = "";
        protected string surname_cadre = "";
        protected string address = "";
        protected string tel = "";
        protected string fax = "";
        protected string email = "";

        /// <summary>
        /// Ім'я користувача
        /// </summary>
        public string UserName
        {
            get { return this.username; }
            set { this.username = value; }
        }

        /// <summary>
        /// Повна назва організації
        /// </summary>
        public string FullName
        {
            get { return this.full_name; }
            set { this.full_name = value; }
        }

        /// <summary>
        /// Повна назва організації в родовому відмінку (з малої літери)
        /// </summary>
        public string FullNameGenitive
        {
            get { return this.full_name_genitive; }
            set { this.full_name_genitive = value; }
        }

        /// <summary>
        /// Скорочена назва організації
        /// </summary>
        public string Abbreviation
        {
            get { return this.abbreviation; }
            set { this.abbreviation = value; }
        }

        /// <summary>
        /// Скорочена назва навчального закладу в родовому відмінку
        /// </summary>
        public string AbbreviationGenitive
        {
            get { return this.abbreviation_genitive; }
            set { this.abbreviation_genitive = value; }
        }

        /// <summary>
        /// Назва організації вищого рівня
        /// </summary>
        public string Subordination
        {
            get { return this.subordination; }
            set { this.subordination = value; }
        }

        /// <summary>
        /// Назва організації вищого рівня у родовому відмінку
        /// </summary>
        public string SubordinationGenitive
        {
            get { return this.subordination_genitive; }
            set { this.subordination_genitive = value; }
        }

        /// <summary>
        /// Назва структурного підроздіту організації
        /// </summary>
        public string Unit
        {
            get { return this.unit; }
            set { this.unit = value; }
        }

        /// <summary>
        /// Місце складання документа
        /// </summary>
        public string Place
        {
            get { return this.place; }
            set { this.place = value; }
        }

        /// <summary>
        /// Код ЄДРПОУ
        /// </summary>
        public string Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        /// <summary>
        /// Банківські реквізити (номер банківського рахунку, назва установи банку, її код)
        /// </summary>
        public string Bank
        {
            get { return this.bank; }
            set { this.bank = value; }
        }

        /// <summary>
        /// Юридична адреса
        /// </summary>
        public string LegalAddress
        {
            get { return this.legal_address; }
            set { this.legal_address = value; }
        }

        /// <summary>
        /// Прізвище, ім’я, по батькові керівника
        /// </summary>
        public string ChiefName
        {
            get { return this.chief_name; }
            set { this.chief_name = value; }
        }

        /// <summary>
        /// Прізвище, імя, по батькові керівника у родовому відмінку
        /// </summary>
        public string ChiefNameGenitive
        {
            get { return this.chief_name_genitive; }
            set { this.chief_name_genitive = value; }
        }

        /// <summary>
        /// Прізвище та ініціали керівника
        /// </summary>
        public string ChiefSurname
        {
            get { return this.chief_surname; }
            set { this.chief_surname = value; }
        }

        /// <summary>
        /// Прізвище та ініціали керівника у давальному відмінку
        /// </summary>
        public string ChiefSurnameDative
        {
            get { return this.chief_surname_dative; }
            set { this.chief_surname_dative = value; }
        }

        /// <summary>
        /// Ініціали та прізвище керівника
        /// </summary>
        public string ChiefInitials
        {
            get { return this.chief_initials; }
            set { this.chief_initials = value; }
        }

        /// <summary>
        /// Посада керівника навчального закладу (з великої літери)
        /// </summary>
        public string ChiefPosition
        {
            get { return this.chief_position; }
            set { this.chief_position = value; }
        }

        /// <summary>
        /// Посада керівника у давальному відмінку (з великої літери)
        /// </summary>
        public string ChiefPositionDative
        {
            get { return this.chief_position_dative; }
            set { this.chief_position_dative = value; }
        }

        /// <summary>
        /// Посада керівника у родовому відмінку (з малої літери)
        /// </summary>
        public string ChiefPositionLower
        {
            get { return this.chief_position_lower; }
            set { this.chief_position_lower = value; }
        }

        /// <summary>
        /// Назва посади керівника кадрової служби
        /// </summary>
        public string PositionCadre
        {
            get { return this.position_cadre; }
            set { this.position_cadre = value; }
        }

        /// <summary>
        /// Назва посади керівника кадрової служби в родовому відмінку
        /// </summary>
        public string PositionCadreGenitive
        {
            get { return this.position_cadre_genitive; }
            set { this.position_cadre_genitive = value; }
        }

        /// <summary>
        /// Ініціали та прізвище керівника кадрової служби
        /// </summary>
        public string InitialsCadre
        {
            get { return this.initials_cadre; }
            set { this.initials_cadre = value; }
        }

        /// <summary>
        /// Прізвище, ініціали керівника кадрової служби
        /// </summary>
        public string SurnameCadre
        {
            get { return this.surname_cadre; }
            set { this.surname_cadre = value; }
        }

        /// <summary>
        /// Поштова адреса організації
        /// </summary>
        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        /// <summary>
        /// Номер телефону організації
        /// </summary>
        public string Telephone
        {
            get { return this.tel; }
            set { this.tel = value; }
        }

        /// <summary>
        /// Номер факсу організації
        /// </summary>
        public string Fax
        {
            get { return this.fax; }
            set { this.fax = value; }
        }

        /// <summary>
        /// Електронна адреса організації
        /// </summary>
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string XmlFilePath
        {
            get; set;
        }

    }
}
