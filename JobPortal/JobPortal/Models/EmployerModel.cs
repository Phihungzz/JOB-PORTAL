﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BCrypt.Net;
namespace JobPortal.Models
{
    public class EmployerModel
    {
        [Key]
        public int EmployerID { get; set; }

        [Required(ErrorMessage = "Tên công ty bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên công ty không được vượt quá 100 ký tự")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email bắt buộc")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string OfficialEmail { get; set; }

        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string ContactPhone { get; set; }

        [Required(ErrorMessage = "Nhập url ")]
        [Url(ErrorMessage = "Website URL không hợp lệ")]
        public string Website { get; set; }
        [Display(Name = "Tên đầy đủ")]
        [Required(ErrorMessage = "Tên bắt buộc")]
        [StringLength(50, ErrorMessage = "Tên không được vượt quá 50 kí tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Chức danh bắt buộc")]
        [StringLength(50, ErrorMessage = "Chức danh không được vượt quá 50 kí tự")]
        public string Designation { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu bắt buộc")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string Status { get; set; }
        public void SetPassword(string password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
    }

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(Password, password);
        }
    }

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Nhập danh mục")]
        public string CategoryName { get; set; }
    }

    public class JobVacancy
    {
        [Key]
        public int VacancyID { get; set; }
        public int EmployerID { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }    
        public string Location { get; set; }
        public decimal Salary { get; set; }
        public string EmploymentType { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime ApplicationDeadline { get; set; }
        public bool IsPublished { get; set; }
    }

    public class Admin{
        [Key]
        public int AdminID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

    }

    public class VacancyViewModel
    {
        public JobDetails JobVacancies { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int Views { get; set; }
    }

    public class JobViewers
    {
        public int ViewId { get; set; }
        public string Username { get; set; }
        public DateTime ViewDateTime { get; set; }
        public int JobId { get; set; }
        public int SeekerId { get; set; }
    }
}