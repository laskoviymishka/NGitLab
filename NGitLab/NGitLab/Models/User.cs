﻿namespace NGitLab.Models
{
	using System;
	using System.Runtime.Serialization;

	[DataContract]
	public class User
	{
		public static string Url = "/users";
		[DataMember(Name = "avatar_url")] public string AvatarURL;

		[DataMember(Name = "bio")] public string Bio;
		[DataMember(Name = "blocked")] public bool Blocked;
		[DataMember(Name = "can_create_group")] public bool CanCreateGroup;

		[DataMember(Name = "can_create_project")] public bool CanCreateProject;
		[DataMember(Name = "created_at")] public DateTime CreatedAt;
		[DataMember(Name = "dark_scheme")] public bool DarkScheme;

		[DataMember(Name = "email")] public string Email;
		[DataMember(Name = "extern_uid")] public string ExternUid;
		[DataMember(Name = "id")] public int Id;
		[DataMember(Name = "is_admin")] public bool IsAdmin;

		[DataMember(Name = "linkedin")] public string Linkedin;
		[DataMember(Name = "name")] public string Name;

		[DataMember(Name = "provider")] public string Provider;
		[DataMember(Name = "skype")] public string Skype;

		[DataMember(Name = "state")] public string State;

		[DataMember(Name = "theme_id")] public int ThemeId;
		[DataMember(Name = "twitter")] public string Twitter;
		[DataMember(Name = "username")] public string Username;

		[DataMember(Name = "website_url")] public string WebsiteURL;
	}
}