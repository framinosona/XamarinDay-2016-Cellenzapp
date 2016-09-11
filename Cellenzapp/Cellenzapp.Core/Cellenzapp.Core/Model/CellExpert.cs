//
// CellExpert.cs
//
// Author:
//       Francois Raminosona <framinosona@hotmail.fr>
//
// Copyright (c) 2016 François Raminosona
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cellenzapp.Core.Model
{
    [DataContract]
    public class Name
    {
        public string Full => $"{First} {Last}";

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "first")]
        public string First { get; set; }

        [DataMember(Name = "last")]
        public string Last { get; set; }
    }

    [DataContract]
    public class Location
    {
        [DataMember(Name = "street")]
        public string Street { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "postcode")]
        public object Postcode { get; set; }
    }

    [DataContract]
    public class Login
    {

        [DataMember(Name = "username")]
        public string Username { get; set; } = "invite";

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "salt")]
        public string Salt { get; set; }

        [DataMember(Name = "md5")]
        public string Md5 { get; set; }

        [DataMember(Name = "sha1")]
        public string Sha1 { get; set; }

        [DataMember(Name = "sha256")]
        public string Sha256 { get; set; }
    }

    [DataContract]
    public class Id
    {

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }
    }

    [DataContract]
    public class Picture
    {

        [DataMember(Name = "large")]
        public string Large { get; set; }

        [DataMember(Name = "medium")]
        public string Medium { get; set; }

        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
    }

    [DataContract]
    public class CellExpert
    {
        [DataMember(Name = "gender")]
        public string Gender { get; set; }

        [DataMember(Name = "name")]
        public Name Name { get; set; } = new Name();

        [DataMember(Name = "location")]
        public Location Location { get; set; } = new Location();

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "login")]
        public Login Login { get; set; } = new Login();

        [DataMember(Name = "dob")]
        public string Dob { get; set; }

        [DataMember(Name = "registered")]
        public string Registered { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "cell")]
        public string Cell { get; set; }

        [DataMember(Name = "id")]
        public Id Id { get; set; } = new Id();

        [DataMember(Name = "picture")]
        public Picture Picture { get; set; } = new Picture();

        [DataMember(Name = "nat")]
        public string Nat { get; set; }

        public Position Position { get; set; } = new Position();
    }

    public class Position
    {
        public string Full => $"{JobTitle} @{Company}";

        public string JobTitle { get; set; }

        public string Company { get; set; }
    }
    [DataContract]
    public class RandomUserResults
    {
        [DataMember(Name = "results")]
        public IList<CellExpert> CellExpert { get; set; }
    }
}
