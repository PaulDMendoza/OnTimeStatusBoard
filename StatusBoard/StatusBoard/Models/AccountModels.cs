using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace StatusBoard.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
    
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }

        /// <summary>
        /// The URL of the OnTime instance without the trailing slash.
        /// </summary>
        public string OnTimeBaseUrl { get; set; }
        /// <summary>
        /// Authorization token returned from OnTime.
        /// </summary>
        public string OnTimeAuthorizationToken { get; set; }
        /// <summary>
        /// UTC time that the authorization token was last set.
        /// </summary>
        public DateTime? AuthorizationDate { get; set; }

        /// <summary>
        /// Tracks how many API requests have been made so far on the LastRequestDate day.
        /// </summary>
        public int? CountRequestsToday { get; set; }
        /// <summary>
        /// Tracks which date the last API request was made. Use in conjunction with field CountRequestsToday
        /// </summary>
        public DateTime? LastRequestDate { get; set; }

        private bool _showDefects = true;
        public bool ShowDefects
        {
            get { return _showDefects; }
            set { _showDefects = value; }
        }

        private bool _showFeatures = true;
        public bool ShowFeatures
        {
            get { return _showFeatures; }
            set { _showFeatures = value; }
        }

        private int _refreshRate = 180;
        /// <summary>
        /// Number of seconds to wait between page refreshes.
        /// </summary>
        public int RefreshRate
        {
            get { return _refreshRate; }
            set { _refreshRate = value; }
        }
    }

    


    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
