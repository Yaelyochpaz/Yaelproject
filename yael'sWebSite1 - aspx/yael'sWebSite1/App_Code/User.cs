using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Xml.Linq;

public class User
{
    
    public string username;
    public string password;
    public string name;
    public string firstname;
    public string lastname;
    public string mail;
    public int gender;
    public string phone;
    public DateTime birth;
    public bool admin;
    public string hintQ;
    public string hintAns;
   // public string ConfirmPass;
   

        public string GetUsername()
    {
        return username;
    }
    public string GetPassword()
    {
        return password;
    }
    public string GetMail()
    {
        return this.mail;
    }
    public DateTime GetBirth()
    {
        return birth;
    }
    public bool GetAdmin()
    {
        return admin;
    }
    public string GetPhone()
    {
        return phone;
    }
    public string GetFirstname()
    {
        return firstname;
    }
    public string GetLastname()
    {
        return lastname;
    }
    public string Getname()
    {
        return name;
    }
    public int GetGender()
    {
        return gender;
    }
    public string GetHintQ()
    {
        return hintQ;
    }
    public string GetHintAns()
    {
        return hintAns;
    }
   /* public string GetConfirmPass()
    {
        return ConfirmPass;
    }
   */
    public void SetUsername(string username)
    {
        this.username = username;
    }
    public void SetAdmin(bool admin)
    {
        this.admin = admin;
    }
    public User()
    {
        phone = "";
        username = "";
        password = "";
        firstname = "";
        lastname = "";
        birth = DateTime.Today;
        gender = 0;
        hintQ = "";
        hintAns = "";
        //ConfirmPass = "";
        mail = "exmaple@domain.com";
        admin = false;

    }
    public User(string username, string password, string name, string mail, int gender, string phone, DateTime birth, bool admin, string hintQ, string hintAns)
    {
        this.username = username;
        this.password = password;
        this.name = name;
        this.mail = mail;
        this.gender = gender;
        this.phone = phone;
        this.birth = birth;
        this.admin = admin;
        this.hintQ = hintQ;
        this.hintAns = hintAns;
        


    }
}