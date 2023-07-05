create database FinalPABD
On (Name='Final_P',
Filename ='D:\PABD\Final Project PABD\FinalPABD.mdf',
Size = 50MB, Filegrowth = 5MB)
Log on (Name='Final_S',
Filename = 'D:\PABD\Final Project PABD\FinalPABD.ldf',
Size = 30MB, Filegrowth = 5MB)
GO


create table Pelanggan (
nama varchar(30),
nik char(16) primary key,
no_hp char(13),
alamat varchar(50))

create table Tiket (
id_tiket varchar(6) primary key,
nm_kereta varchar(15),
no_kursi char(2),
keberangkatan varchar(20),
tujuan varchar (20),
)

create table Stasiun (
nm_stasiun varchar(20),
id_stasiun varchar(6) primary key,
keberangkatan varchar(20),
tujuan varchar(20),
id_tiket varchar(6) constraint kode_tiket foreign key (id_tiket) references Tiket(id_tiket)
)

create table Kereta (
nm_kereta varchar(15),
id_kereta varchar(8) primary key,
jns_kereta varchar(15),
id_stasiun varchar(6) constraint id_stasiun foreign key (id_stasiun) references Stasiun(id_stasiun)
)

create table Gerbong (
id_gerbong varchar(6) primary key,
no_gerbong char(1),
kelas varchar(10),
kapasitas char(2),
id_kereta varchar(8) constraint id_kereta foreign key (id_kereta) references Kereta(id_kereta)
)

create table Pemesanan (
id_pemesanan varchar(6) primary key,
id_tiket varchar(6) constraint id_tiket foreign key (id_tiket) references Tiket(id_tiket),
nik char(16) constraint nik foreign key (nik) references Pelanggan(nik),
no_hp char(13)
)