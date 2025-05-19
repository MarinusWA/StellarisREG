using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;

public static class CookieHelper
{
	public static void SetJsonCookie(HttpResponse response, string key, IEnumerable<string> set, CookieOptions? options = null)
	{
		set ??= new HashSet<string>();
		var json = JsonSerializer.Serialize(set);
		
		response.Cookies.Append(key, json, options ?? new CookieOptions
		{
			Expires = DateTimeOffset.Now.AddYears(1),
			SameSite = SameSiteMode.Lax,
			Secure = true,
			HttpOnly = false
		});
	}

	public static T? GetJsonCookie<T>(HttpRequest request, string key)
	{
		if (request.Cookies.TryGetValue(key, out var json))
		{
			try
			{
				return JsonSerializer.Deserialize<T>(json);
			}
			catch
			{
				// Handle malformed JSON or type mismatch
			}
		}

		return default;
	}
}
