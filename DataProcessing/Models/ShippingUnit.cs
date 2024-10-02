﻿using DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class ShippingUnit
    {
        public Guid ShippingUnitID { get; set; } 

        [Required(ErrorMessage = "Tên đơn vị giao hàng là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên đơn vị giao hàng không được quá 100 ký tự.")]
        public string Name { get; set; }         

        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        [StringLength(15, ErrorMessage = "Số điện thoại không được quá 15 ký tự.")]
        public string Phone { get; set; }        

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }        

        [StringLength(200, ErrorMessage = "Địa chỉ không được quá 200 ký tự.")]
        public string Address { get; set; }      

        [Url(ErrorMessage = "Địa chỉ website không hợp lệ.")]
        public string? Website { get; set; }     

        public bool Status { get; set; }

        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }
    }
}