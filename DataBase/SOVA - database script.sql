SET SESSION sql_mode = 'STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION';


drop DATABASE if exists SOVA;
CREATE DATABASE SOVA;
use SOVA;
ALTER SCHEMA `SOVA`  DEFAULT CHARACTER SET utf8 ;

drop table if exists posts1;


create table posts1
	(id int(11), 
    posttypeid int(11), 
    owneruserid int(11), 
    parentid int(11),
    acceptedanswerid int(11), 
    creationdate datetime,
    score int(11), 
    body longtext, 
    closeddate datetime, 
    title varchar(200), 
    linkpostid int(11));
    
 select *
 from posts1;
    
insert into posts1 (id, posttypeid, owneruserid, parentid,acceptedanswerid, creationdate,score, body, closeddate, title, linkpostid)
SELECT id, posttypeid, owneruserid, parentid,acceptedanswerid, creationdate,score, body, closeddate, title, linkpostid 
	FROM stackoverflow_sample_universal.posts;


 select *
 from posts1;
 
 
 drop table if exists poststag;
create table poststag
	(id int(11),
     tag1 varchar (100),
     tag2 varchar (100),
     tag3 varchar (100),
     tag4 varchar (100),
     tag5 varchar (100));
     
     
select *
	from poststag;  

insert into poststag (id,tag1,tag2,tag3,tag4,tag5)
 select id,part1 as tag1,part2 as tag2, part3 as tag3, part4 as tag4, part5 as tag5
	from (select distinct id,
	  substring_index(substring_index(tags, '::', -5), '::',1) as part1,
      substring_index(substring_index(tags, '::', -4), '::',1) as part2,
      substring_index(substring_index(tags, '::', -3), '::',1) as part3,
      substring_index(substring_index(tags, '::', -2), '::', 1)as part4,
      substring_index(tags, '::', -1) as part5
			FROM stackoverflow_sample_universal.posts
				where posttypeid=1) as xx
          where (part1 <> part2 and part2 <> part3 and part3 <> part4 and part4 <> part5);  

                 

insert into poststag (id,tag1,tag2,tag3,tag4,tag5)                 
select id,part2 as tag1, part3 as tag2, part4 as tag3, part5 as tag4, null
	from (select distinct id,
	  substring_index(substring_index(tags, '::', -5), '::',1) as part1,
      substring_index(substring_index(tags, '::', -4), '::',1) as part2,
      substring_index(substring_index(tags, '::', -3), '::',1) as part3,
      substring_index(substring_index(tags, '::', -2), '::', 1)as part4,
      substring_index(tags, '::', -1) as part5
			FROM stackoverflow_sample_universal.posts
				where posttypeid=1) as xx

          where (part2 <> part3 and part3 <> part4 and part4 <> part5 and part1 = part2);  


 
insert into poststag (id,tag1,tag2,tag3,tag4,tag5)
select id,part3 as tag1, part4 as tag2, part5 as tag3, null,null
	from (select distinct id,
	  substring_index(substring_index(tags, '::', -5), '::',1) as part1,
      substring_index(substring_index(tags, '::', -4), '::',1) as part2,
      substring_index(substring_index(tags, '::', -3), '::',1) as part3,
      substring_index(substring_index(tags, '::', -2), '::', 1)as part4,
      substring_index(tags, '::', -1) as part5
			FROM stackoverflow_sample_universal.posts
				where posttypeid=1) as xx
          where (part3 <> part4 and part4 <> part5 and part1 = part2 and part2 = part3); 



                 
insert into poststag (id,tag1,tag2,tag3,tag4,tag5)
select id,part4 as tag1, part5 as tag2, null,null,null
	from (select distinct id,
	  substring_index(substring_index(tags, '::', -5), '::',1) as part1,
      substring_index(substring_index(tags, '::', -4), '::',1) as part2,
      substring_index(substring_index(tags, '::', -3), '::',1) as part3,
      substring_index(substring_index(tags, '::', -2), '::', 1)as part4,
      substring_index(tags, '::', -1) as part5
			FROM stackoverflow_sample_universal.posts
				where posttypeid=1) as xx
          where (part4 <> part5 and part1 = part2 and part2 = part3 and part3 = part4); 


          
insert into poststag (id,tag1,tag2,tag3,tag4,tag5)          
select id,part5 as tag1,null,null,null,null
	from (select distinct id,
	  substring_index(substring_index(tags, '::', -5), '::',1) as part1,
      substring_index(substring_index(tags, '::', -4), '::',1) as part2,
      substring_index(substring_index(tags, '::', -3), '::',1) as part3,
      substring_index(substring_index(tags, '::', -2), '::', 1)as part4,
      substring_index(tags, '::', -1) as part5
			FROM stackoverflow_sample_universal.posts
				where posttypeid=1) as xx
          where (part1 = part2 and part2 = part3 and part3 = part4 and part4 = part5);           


select *
	from poststag
    order by id;
	

drop table if exists postsowner;
create table postsowner
   (id int (11),
	owneruserid int (11),
	owneruserdisplayname varchar (50),
	ownerusercreationdate datetime,
	postsownercountry varchar (100),
    postsownercity varchar (100),
	owneruserage int(11),
	linkpostid int (11));



select* 
from postsowner
order by id;



insert into postsowner (id,owneruserid, owneruserdisplayname,ownerusercreationdate, postsownercountry,postsownercity,owneruserage,linkpostid)
    select  distinct id,owneruserid, owneruserdisplayname,ownerusercreationdate, postsownercountry,postsownercity,owneruserage,linkpostid
	from (select id,owneruserid, owneruserdisplayname,ownerusercreationdate, substring_index(owneruserlocation, ',', 1) as postsownercity,
			substring_index(owneruserlocation, ',', -1) as postsownercountry, owneruserage,linkpostid
			FROM stackoverflow_sample_universal.posts) as xx
		where postsownercity <> postsownercountry;


insert into postsowner (id,owneruserid, owneruserdisplayname,ownerusercreationdate, postsownercountry,postsownercity,owneruserage,linkpostid)
    select  distinct id,owneruserid, owneruserdisplayname,ownerusercreationdate, postsownercountry,null,owneruserage,linkpostid
	from (select id,owneruserid, owneruserdisplayname,ownerusercreationdate, substring_index(owneruserlocation, ',', 1) as postsownercity,
			substring_index(owneruserlocation, ',', -1) as postsownercountry, owneruserage,linkpostid
			FROM stackoverflow_sample_universal.posts) as xx
		where postsownercity = postsownercountry;
    
    

insert into postsowner (id,owneruserid, owneruserdisplayname,ownerusercreationdate, postsownercountry,postsownercity,owneruserage,linkpostid)
    select  distinct id,owneruserid, owneruserdisplayname,ownerusercreationdate, null,null,owneruserage,linkpostid
	from (select id,owneruserid, owneruserdisplayname,ownerusercreationdate, substring_index(owneruserlocation, ',', 1) as postsownercity,
			substring_index(owneruserlocation, ',', -1) as postsownercountry, owneruserage,linkpostid
			FROM stackoverflow_sample_universal.posts ) as xx
            where postsownercity is null and postsownercountry is null ;    
            
            
            
insert into postsowner (id,owneruserid, owneruserdisplayname,ownerusercreationdate, postsownercountry,postsownercity,owneruserage,linkpostid)
    select  distinct id,owneruserid, owneruserdisplayname,ownerusercreationdate, null,postsownercity,owneruserage,linkpostid
	from (select id,owneruserid, owneruserdisplayname,ownerusercreationdate, substring_index(owneruserlocation, ',', 1) as postsownercity,
			substring_index(owneruserlocation, ',', -1) as postsownercountry, owneruserage,linkpostid
			FROM stackoverflow_sample_universal.posts ) as xx
            where postsownercountry is null and postsownercity is not null; 
          
select* 
from postsowner;
	



drop table if exists postsowneridtoowner;
create table postsowneridtoowner
   (id int (11),
	owneruserid int (11));


select*
from postsowneridtoowner;


insert into postsowneridtoowner (id,owneruserid)
    select id,owneruserid
    from postsowner;

select*
from postsowneridtoowner
order by owneruserid;
    

drop table if exists postsownerownerinf;
create table postsownerownerinf
   (owneruserid int (11),
	owneruserdisplayname varchar (50),
	ownerusercreationdate datetime,
	postsownercountry varchar (100),
    postsownercity varchar (100),
	owneruserage int(11),
	linkpostid int (11));

select*
from postsownerownerinf;

insert into postsownerownerinf (owneruserid, owneruserdisplayname, ownerusercreationdate, postsownercountry, postsownercity, owneruserage,linkpostid)
    select owneruserid, owneruserdisplayname, ownerusercreationdate, postsownercountry, postsownercity, owneruserage,linkpostid
    from postsowner;

select*
from postsownerownerinf;

drop table if exists commentsbody;
create table commentsbody
	(commentid int(11),
    postid int(11), 
    commentscore int(11),
    commenttext longtext, 
    commentcreatedate datetime, 
    userid int(11));

select *
	from commentsbody;     
    
insert into commentsbody (commentid,postid, commentscore,commenttext, commentcreatedate, userid)
select commentid,postid, commentscore,commenttext, commentcreatedate, userid
	from stackoverflow_sample_universal.comments;

select *
	from commentsbody;
	
drop table if exists commentuser;
create table commentuser
	(commentid int(11),
     userid int(11),
     userdisplayname varchar (30),
     userage int (11),
     userlocationcountry varchar (100),
     userlocationcity varchar (100),
	 usercreationdate datetime);


select *
from commentuser;
 
insert into commentuser (commentid,userid, userdisplayname, userage, userlocationcountry, userlocationcity, usercreationdate)
select commentid,userid, userdisplayname, userage,userlocationcountry,userlocationcity,usercreationdate
	from (select distinct commentid,userid,userdisplayname, userage,substring_index(userlocation, ',', 1) as userlocationcity,
        substring_index(userlocation, ',', -1) as userlocationcountry,usercreationdate
        FROM stackoverflow_sample_universal.comments) as xx
		where userlocationcity <> userlocationcountry;

       

insert into commentuser (commentid,userid, userdisplayname, userage, userlocationcountry,userlocationcity, usercreationdate)
select commentid,userid, userdisplayname, userage,userlocationcountry,null,usercreationdate
	from (select distinct commentid,userid,userdisplayname, userage,substring_index(userlocation, ',', 1) as userlocationcity,
        substring_index(userlocation, ',', -1) as userlocationcountry,usercreationdate
        FROM stackoverflow_sample_universal.comments) as xx
		where userlocationcity = userlocationcountry;

select *
from commentuser
order by commentid;







drop DATABASE if exists sova_history_and_mark;
CREATE DATABASE sova_history_and_mark;
use sova_history_and_mark;
ALTER SCHEMA `sova_history_and_mark`  DEFAULT CHARACTER SET utf8 ;

drop table if exists searchhistory;

create table searchhistory
	(searchnumberid int(11), 
    searchstring varcharacter(100), 
    searchdate datetime); 
        
    
 select *
 from searchhistory ;
 
 drop table if exists personal_notes;

create table personalnotes
	(noteid int(11), 
     userid int(11), 
     postid int(11), 
     commentsid int(11), 
     id int(11), 
     notestring varcharacter(100), 
     notecreationdate datetime); 
        
    
 select *
 from personalnotes ;
 
 drop table if exists marked;
create table marked
	(markedid int(11), 
     userid int(11), 
     postid int(11), 
     commentsid int(11), 
     id int(11), 
	 markedstring varcharacter(100), 
     markedcreationdate datetime);
    
select *
	from marked;

use SOVA;
drop procedure if exists search;
delimiter //
create procedure search (wordstring varchar(255))
begin
	select id, title, body, acceptedanswerid,parentid, posttypeid, score, commenttext,commentscore, commentsbody.commentid
		from posts1 join commentsbody on id=postid 
			where  posts1.body like concat('%',wordstring,'%') 
            or posts1.title like concat('%',wordstring,'%')
            or commentsbody.commenttext like concat('%',wordstring,'%') 
            and id = parentid
	group by id, parentid
	order by score desc;
    end;//

Call search('how to');
