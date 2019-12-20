# BAMS
BANK ACCOUNT MANAGEMENT SYSTEM/ C# .NET


Banka yönetim sistemi çalışanlara müşterilerin ve bankanın verilerine erişme özelliğini sağlamaktadır.

Dashboard sayfasında bankanın sayısal verileri chart bileşeni kullanarak göstermektedir, 
Client sayfasında hem müşteriler gösterir, 
hem de yeni müşteri ekleyebilir veya daha önce kayıtlı olan müşterinin silme ve bilgileri değiştirme yapabilir,
Transactions sayfasında para çekme ve para yatırma işlemeleri gerçekleştirilebilir ve hesapların arasında İBAN kullanarak para aktarması bulunacak,
Employee sayfasında çalışanların ve yönetmenlerin bilgilerinin üzerinde farklı işlemler yapılabilir, ve başka işlemler yapabilecek.

Verileri kaydetmek için SQL server platformu kullanılacak,
ve kullanıcı arayüzü için c# ve vs.NET platformları kullanılacak

written by: Sami KWHAIREH

# HOME
home sayfasında bankada var olan çeşitli para birimleri ile banka hesap bakiyeleri chart bileşnleri kullanarak gösterilmektedir
her bir `solid Gauge` belişeninde verinin göstermesi için `sql server` veri tabanınında kullnılan `query` kod olarak :
```
select count(CurrencyID) as Totbalance from tblAccount where CurrencyID = 1
```

`Pie chart` belişeni için `sql server` veri tabanınında kullanılan `query` kod olarak :
```
select sum(Balance) as Totbalance from tblAccount where CurrencyID = 1
```

# Customer 
Customer sayfasında tüm banka müşterileri `view` ve `join` ile kullanarak gösterilmektedir,
```
SELECT dbo.tblCustomer.ID, dbo.tblCustomer.firstname,
dbo.tblCustomer.lastname, dbo.tblCustomer.Email,
dbo.tblCustomer.Phone, dbo.tblCustomerJobs.Job, 
dbo.tblCustomer.Address, dbo.tblGender.Gender, dbo.tblCustomer.Birth, 
                  dbo.tblBranch.Branch
FROM     dbo.tblCustomer 
INNER JOIN
 dbo.tblCustomerJobs ON dbo.tblCustomer.Job_id = dbo.tblCustomerJobs.id 
 INNER JOIN
 dbo.tblGender ON dbo.tblCustomer.Gender_id = dbo.tblGender.id 
 INNER JOIN
 dbo.tblBranch ON dbo.tblCustomer.Barnch_id = dbo.tblBranch.id_
```

müşteriler tablosunda `view`, `join` ile kullanarak arama yapabilimekte, 
```
select * from vWCustomerdata where firstname like
'" + tbsearch.Text+"%' or ID like '"+tbsearch.Text+"%'
```

`view, join ve group by` kullanarak müşteriler tablosu branch tablosu ile birleştirerek gösterebilir
```
SELECT dbo.tblBranch.Branch, COUNT(dbo.tblCustomer.ID) AS total_Customer
FROM    dbo.tblCustomer INNER JOIN
dbo.tblCustomerJobs ON dbo.tblCustomer.Job_id = dbo.tblCustomerJobs.id 
INNER JOIN
 dbo.tblGender ON dbo.tblCustomer.Gender_id = dbo.tblGender.id 
 INNER JOIN
 dbo.tblBranch ON dbo.tblCustomer.Barnch_id = dbo.tblBranch.id_
GROUP BY dbo.tblBranch.Branch
```

aynı şekilde `vWDisplyCards` kullanarak gouplandırabilir

yeni bir müşteri eklemek için `stored procedure` kullanılmıştır
```
CAREATE PROC [dbo].[addCustomer]
@firstname nvarchar(50),
@lastname nvarchar(50),
@email nvarchar(50),
@phone nvarchar(50),
@jobID int,
@address nvarchar(max),
@genderID nvarchar(50),
@birth nvarchar(50),
@branchID int 
as
begin 
INSERT INTO tblCustomer values(@firstname, @lastname, @email,
@phone, @jobID, @address, @genderID, @birth, @branchID)
end
```

yeni bir şübe eklemek için `stored procedure` kullanılmıştır
```
CREATE PROC addBranch
@name nvarchar(50)
AS 
begin 
insert into tblBranch values(@name)
end 
```
*tüm şübeler `combobox` de gösterilir

bir müşteri silmek için `stored procedure` kullanılmıştır
```
CREATE proc [dbo].[deleteCustomer]
@id int
as 
begin
Delete from tblCustomer where ID = @id
end
```
silme işlemi gerçekleştirdiğinde aynı zamanda `TRİGGER` kullanarak<br/> 
silinmiş müşterinin account ve card tablolarında verleri varsa silinecektır
ve silinmiş datayı `removed` tablosuna eklenecektir
```
alter TRIGGER TR_tblCustomer
ON tblCustomer
FOR DELETE
as
BEGIN 

DECLARE 
@id int, 
@firstname nvarchar(50),
@lastname nvarchar(50),
@email nvarchar(50),
@phone nvarchar(50),
@jobid int,
@address nvarchar(max),
@genderid int, 
@birth nvarchar(50),
@branchid int

select @id = ID , @firstname = firstname , @lastname = lastname , 
@email = Email , @phone = Phone , @jobid = Job_id , @address = Address , 
@genderid = Gender_id , @birth = Birth , @branchid = Barnch_id from deleted 

delete FROM tblAccount WHERE ID_ = @id
delete FROM tblCard WHERE ID = @id

INSERT INTO tblRemoved_Customer Values (@id, @firstname,
@lastname, @email, @phone, @jobid, @address, @genderid,
@birth, @branchid, CAST(getdate() as nvarchar(50)) )

END
```

# Transactions
Transactions sayfasında müşterinin hesabı yukarıdaki tablodan seçerek,<br/>
müşterilerin arasında para transferi, para yatırma ve para çekme gibi işlemler gerçekleştirebilir<br/>
gerçekleştirilmiş Transactions işlemler aşağıdaki tabloda gösterilmekte.

# History
History sayfasında view, `join` kullanarak silinmiş müşterilerin dataları gösterilmektedir, ve view de arama yapabilir.
```
create view vWRemovedCustomers
as select  _ID, _firstname, _lastname, _Email, _Phone,
Job , _Address, Gender,  _Birth, branch, remove_date
From tblRemoved_Customer 
INNER JOIN tblCustomerJobs ON tblRemoved_Customer._Job_id = tblCustomerjobs.id
INNER JOIN tblGender  ON tblRemoved_Customer._Gender_id = tblGender.id
INNER JOIN tblBranch ON tblRemoved_Customer._Branch_id = tblBranch.id_
```

# Account
Account sayfasında müşterilerin banka hesabalarını `join` kullanarak gösterilir.
```
query = " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id";
```
ve `join - where` kullanarak para birimlerine göre sınıflandırabilirdir 
```
query = " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id" +
                       " where CurrencyType = 'USD'";
```
hesap bakyesine göre iki aralık arasında arama yaplıablir 
```
query = " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id" +
                       " where Balance between "+from+" and "+to+"";
```
yeni bir hesap ve yeni bir para birimi `stored procedure` kullanarak eklenebilir.

# Employee
Employee sayfasında bankadaki çalışanlarının bilgilerini `join` kullanarak farklı şekilde gösterilmekte, ve verilerin 
üzernde `update`, `ekleme`, `activity değiiştirme` işlemler gibi gerçekleştirilebilmektedir
```
" select ID_,Firstname,Lastname,Username,
JobTitle,Activity,Salary,Email" +
         " from tblEmployee" +
            " INNER JOIN tblJobTitle" +
            " ON tblEmployee.Job_ID = tblJobTitle.id";
```

ve `stored procedure` kullanarak yeni eleman eklenir
```
ALTER proc [dbo].[addEmployee]
@fname nvarchar(50),
@lname nvarchar(50),
@user nvarchar(50),
@pass nvarchar(50),
@jobid nvarchar(50),
@activity nvarchar(50),
@salary nvarchar(50),
@email nvarchar(50)
as
begin 
insert into tblEmployee(Firstname,Lastname,
Username,Password,Job_ID,Activity,Salary,Email)
values(@fname,@lname,@user,@pass,@jobid,@activity,@salary,@email)
end
```

# github
https://github.com/samijihd/BAMS
