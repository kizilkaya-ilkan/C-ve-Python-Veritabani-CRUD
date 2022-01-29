import pypyodbc


# Veritabanı bağlantı bilgileri
db = pypyodbc.connect("DRIVER={SQL Server};SERVER=HUAWEI\SQLEXPRESS;DATABASE=kütüphane")
imlec = db.cursor()
imlec.execute('SELECT * FROM kütüphane')
sonuc = imlec.fetchall()
cevap = input("""
              1- Veritabanı Görüntüle
              2- Ekle
              3- Güncelle
              4- Sil
              5- Çıkış
Yapmak istediğiniz işlemi tuşlayınız: """)
if int(cevap) == 1:
    for i in sonuc:
        print(i)
if int(cevap) == 2:
     id = input("ID Giriniz:")
     kitap = input("Kitap ismi giriniz: ")
     yazar = input("Yazar ismi giriniz: ")
     komut = 'INSERT INTO kütüphane VALUES(?,?,?)'
     veriler = (int(id),kitap,yazar)
     sonuc = imlec.execute(komut,veriler)
     db.commit()
if int(cevap) == 3:
    idGüncelle = input("Güncellemek istediğiniz id giriniz: ")
    degistirilecekAd = input("kitap adı yazınız: ")
    degistirilecekAx = input("yazar adı yazınız: ")
    sonuc = imlec.execute('UPDATE kütüphane SET kitap_ismi = ? , yazar_ismi = ? WHERE id = ?',(degistirilecekAd,degistirilecekAx,int(idGüncelle)))
    db.commit()
    print(str(sonuc) + " Veriler güncellendi")
if int(cevap) == 4:
    silinecekID = input("Silinecek ID belirtiniz. ")
    sonuc = imlec.execute('DELETE FROM kütüphane WHERE id = ?',(silinecekID,))
    db.commit()
    
print(str(sonuc) + " kullanıcı silindi")
if int(cevap) == 5:
    exit()
     


