﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.BanGiay.Models
{
	public class LoginModel
	{
		[Required]
		public String UserName { get; set; }
		public String Password { get; set; }

	}

}