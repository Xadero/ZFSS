﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZfssUZ.AutomatedTests.PageObjects
{
    public class RegisterUser
    {
        private readonly IWebDriver driver;
        public RegisterUser(IWebDriver driver)
        {
            this.driver = driver;

            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Nazwa użytkownika
        /// </summary>
        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement Username { get; set; }

        /// <summary>
        /// Hasło
        /// </summary>
        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }

        /// <summary>
        /// Potwierdź hasło
        /// </summary>
        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        public IWebElement ConfirmPassword { get; set; }

        /// <summary>
        /// Imię
        /// </summary>
        [FindsBy(How = How.Id, Using = "Firstname")]
        public IWebElement Firstname { get; set; }

        /// <summary>
        /// Nazwisko
        /// </summary>
        [FindsBy(How = How.Id, Using = "LastName")]
        public IWebElement LastName { get; set; }

        /// <summary>
        /// Data urodzenia
        /// </summary>
        [FindsBy(How = How.Id, Using = "DateOfBirth")]
        public IWebElement DateOfBirth { get; set; }

        /// <summary>
        /// Numer telefonu
        /// </summary>
        [FindsBy(How = How.Id, Using = "PhoneNumber")]
        public IWebElement PhoneNumber { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [FindsBy(How = How.Id, Using = "EmailAddress")]
        public IWebElement EmailAddress { get; set; }

        /// <summary>
        /// Adres
        /// </summary>
        [FindsBy(How = How.Id, Using = "Address")]
        public IWebElement Address { get; set; }

        /// <summary>
        /// Kod poczatowy
        /// </summary>
        [FindsBy(How = How.Id, Using = "PostCode")]
        public IWebElement PostCode { get; set; }

        /// <summary>
        /// Miejscowość
        /// </summary>
        [FindsBy(How = How.Id, Using = "City")]
        public IWebElement City { get; set; }

        /// <summary>
        /// Grupa użytkownikó
        /// </summary>
        [FindsBy(How = How.Id, Using = "UserGroup_Id")]
        public IWebElement UserGroup { get; set; }

        /// <summary>
        /// Zapisz
        /// </summary>
        [FindsBy(How = How.Id, Using = "Save")]
        public IWebElement Save { get; set; }

        /// <summary>
        /// Powrót
        /// </summary>
        [FindsBy(How = How.Id, Using = "Back")]
        public IWebElement Back { get; set; }
    }
}
