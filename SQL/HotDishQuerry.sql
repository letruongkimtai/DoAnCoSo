
CREATE VIEW HOTDISH as
SELECT        a.Mamon, b.Tenmon, b.GIABAN, b.ANH, SUM(a.SOLUONG) AS SOLUONGMUA
FROM            dbo.CHITIETDONTHANG AS a INNER JOIN
                         dbo.CTMONAN AS b ON a.Mamon = b.Mamon
GROUP BY a.Mamon, b.Tenmon, b.GIABAN, b.ANH
