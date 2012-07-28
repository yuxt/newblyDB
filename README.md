newblyDB
========

Test Mongo database
-------------------

Login: andrew, pass: asd123

To connect using the shell:
mongo ds035907.mongolab.com:35907/newbly -u <user> -p <password>
To connect using a driver via the standard URI (what's this?):
  mongodb://<user>:<password>@ds035907.mongolab.com:35907/newbly

What we have so far (initial database design):
--------------------------
``` JSON
ContentBase -- base, raw content item
{
  ObjectId Id, -- objectId it's common mongodb type for ids, optimized for fast quering 
  string SubmittedBy, -- id of user (admin) who have submitted content item
  Tags[], -- array of tags, related to the content,
  string RawBody, --body of content item, can contains anything, html, text, links. will be manager through the wysiwyg editor
  int Permissions[],-- Array of user permissions, enumeration, in database we store integer number. User(0)|Admin(1)
  DateTime DatePosted, -- date when content was created,
  
   Votes[]{  -- reddit like rating, may not be used
   User -- reference to the user who have voted,
   Rating -- interger value, can be +1/-1 (up/down) or 1 - 5 (5 starts),  
  },

  float Rating -- denormalized rating, need to be updated via client logic on each new vote (possibly async)

}

ImageContent -- on a client side inherited from ContentBase
{
   string ImageUrl, -- url of an image,
   int Height,
   int Width
}

We can have as much inherited content items as application need (Video, html, question, etc..). 

To render content items we load all items as ContentBase and on client side cheching actual type of content item.
Any language mongodb driver will store with content special field _t -- witch contains actual type of an object


User
{
  string Id, -- id of user, possible to be integer, string or ObjectId 
  Email,
  NickName,
  Child, -- child gender, can be Boy or Girl, enumeration -- in db we store 1 or 2,
  Parent, -- Enumeration, in database we will store integer value. Can be Mother(0)|Father(1)|GrandMother(2), and so on based on application logic
  DateOfBirth,
  Location{
	Country,
 	City,
	Zip,
        State
  },
  TimeZone,
  Metadata{
	Date LastAccessDate,
        Date CreatedDate,
 	ClientInfos[]{  -- Information obtained from user devices. Not from each request, if user already requested service from this device -- don't store. (atomic updates $ne)
		Device,
                Ip
                ...			          		
        }
  }
}

TimeLine -- object that will contains information for specific date and hour
{
   integer Day, --Specific day, in DB will be 1065(3 years) such items. One item per one day.
   ContentItems[]{
	ContentId, -- logical reference to Content item,
        int Hours[], -- array of integer values [0,23]
        string Title -- Possible to denormalize content Title, for fast retrieving (depends on app logic)
   }   
}

```

Basic application logic:
========

1. When Administrator add new content item for specific month (or range) -- we should insert this reference into all days (TimeLines)
2. When user login we should insert user client device information into User metadata ClientInfos nested collection, but not each time when
he login (check if same IP/device exists)


Some ideas
========
1. Content item comments -- third party service or facebook comments.
2. Predications -- machine learning (http://en.wikipedia.org/wiki/Machine_learning) or expert systems (http://en.wikipedia.org/wiki/Expert_system).
Machine learning -- is really good thing, that can automatically help parents, based on answers of another parents.
Expert systems -- this simpler to implement, but in will require a lot of admin management/input.



