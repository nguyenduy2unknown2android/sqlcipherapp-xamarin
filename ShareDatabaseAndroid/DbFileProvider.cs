
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net;

namespace ShareDatabaseAndroid
{
	[ContentProvider (new[]{"net.zetetic.dbfile.Provider"}, Label="Zetetic DbFile Provider")]
	class DbFileProvider : ContentProvider
	{
		public static Android.Net.Uri CONTENT_URI =  Android.Net.Uri.Parse("content://net.zetetic.dbfile.Provider/");

		public override string GetType (Android.Net.Uri uri)
		{
			return "application/x-net-zetetic-dbfile";
		}

		public override bool OnCreate ()
		{
			return true;
		}

		public override ParcelFileDescriptor OpenFile (Android.Net.Uri uri, string mode)
		{
			string fileName = 
				Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), uri.LastPathSegment);

			return ParcelFileDescriptor.Open(new Java.IO.File(fileName), ParcelFileMode.ReadOnly);
		}

		public override int Delete (Android.Net.Uri uri, string selection, string[] selectionArgs)
		{
			return 0;
		}

		public override Android.Net.Uri Insert (Android.Net.Uri uri, ContentValues values)
		{
			return null;
		}

		public override Android.Database.ICursor Query (Android.Net.Uri uri, string[] projection, string selection, string[] selectionArgs, string sortOrder)
		{
			return null;
		}

		public override int Update (Android.Net.Uri uri, ContentValues values, string selection, string[] selectionArgs)
		{
			return 0;
		}
	}
}
