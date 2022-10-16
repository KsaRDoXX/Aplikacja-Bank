using System;
using System.Collections.Generic;
using System.Text;

namespace Bankomat_X.Models
{
	
    public class User
    {
        public static List<User> UserList = new List<User>();

        private static int Counter = 0;
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}
		
		public User(string name)
		{
			this.Name = name;
			Counter += 1;

			this.id = Counter;
			UserList.Add(this);
		}
	}
}
