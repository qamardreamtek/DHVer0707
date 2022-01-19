using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadzenDh5.Data
{
    // NOTE by Mark, 2021-04-23
    // 這裡放的是全局且跨用戶共同使用的
    // 應用上, 限制 static 
    public class DhGlobalStatic
    {
        public static string V_LOC_DTL_MST = @"

CREATE VIEW [dbo].[V_LOC_DTL_MST] AS 
SELECT T1.* , T2.EQU_NO,T2.LOC_STS
FROM LOC_DTL T1
LEFT JOIN LOC_MST T2
ON T1.LOC_NO = T2.LOC_NO AND T1.SU_ID = T2.SU_ID
   where T1.STGE_TYPE='ATR' and T2.LOC_STS='S' and T1.GTIN_ALO_QTY=0
                

";


        public static string V_LOC_DTL_MST__PLT_DTL = @"

CREATE VIEW [dbo].[V_LOC_DTL_MST__PLT_DTL] AS 
SELECT a.* , b.IN_NO,b.GR_DATE,b.DATE_CODE,b.IN_LINE FROM V_LOC_DTL_MST a
JOIN PLT_DTL b
 --on (
 --a.WHSE_NO=b.WHSE_NO 
 --and a.PLANT=b.PLANT 
 --and a.STGE_LOC=b.STGE_LOC 
 --and a.SKU_NO=b.SKU_NO 
 --and a.BATCH_NO=b.BATCH_NO 
 --and a.STK_SPECIAL_IND=b.STK_SPECIAL_IND
 --and a.STK_SPECIAL_NO=b.STK_SPECIAL_NO
 --and a.GTIN_UNIT=b.GTIN_UNIT 
 --and a.SU_ID=b.SU_ID)
  on (a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(a.BATCH_NO,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.GTIN_UNIT=b.GTIN_UNIT and a.SU_ID=b.SU_ID)
                 
            

";


        public static string V_LOC_DTL_MST__PLT_DTl__IN_DTL = @"

CREATE VIEW V_LOC_DTL_MST__PLT_DTL__IN_DTL AS 
select b.*, c.INSP_LOT, c.GTIN_NO, c.REQM_NO from V_LOC_DTL_MST__PLT_DTL b
                    join IN_DTL c 
                    on (b.WHSE_NO=c.WHSE_NO and b.IN_NO=c.IN_NO and b.IN_LINE=c.IN_LINE)          

";






        public static string V_C010 = @"

            CREATE VIEW V_C010 AS 
select a.WHSE_NO,a.STGE_TYPE,a.STGE_BIN,a.SU_ID,a.LOC_NO,d.EQU_NO,a.PLANT,a.STGE_LOC,a.SKU_NO,a.BATCH_NO,c.SKU_BATCH,c.SKU_SNO_IND,a.TRN_DATE,e.GTIN_MAX_QTY,max(b.COUNT_DATE) as COUNT_DATE,sum(b.GTIN_QTY) as GTIN_QTY,sum(b.SKU_QTY) as SKU_QTY,a.GTIN_QTY as LOC_QTY,a.GTIN_UNIT,a.SKU_UNIT
                    from LOC_DTL a 
                    join PLT_DTL b on (a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(a.BATCH_NO,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.GTIN_UNIT=b.GTIN_UNIT and a.SU_ID=b.SU_ID)
                    join SKU_MST c on (a.SKU_NO=c.SKU_NO)
                    join LOC_MST d on (a.LOC_NO=d.LOC_NO and a.SU_ID=d.SU_ID)
                    join SKU_SUT e on (a.WHSE_NO=e.WHSE_NO and a.SU_TYPE=e.SU_TYPE and a.SKU_NO=e.SKU_NO and a.GTIN_UNIT=e.GTIN_UNIT)
                    where a.STGE_TYPE='ATR' and d.LOC_STS='S' and a.GTIN_ALO_QTY=0
					
	
                    group by a.WHSE_NO,a.STGE_TYPE,a.STGE_BIN,a.SU_ID,a.LOC_NO,d.EQU_NO,a.PLANT,a.STGE_LOC,a.SKU_NO,a.BATCH_NO,c.SKU_BATCH,c.SKU_SNO_IND,a.TRN_DATE,e.GTIN_MAX_QTY,a.GTIN_QTY,a.GTIN_UNIT,a.SKU_UNIT
                    having a.TRN_DATE > max(b.COUNT_DATE)
                

";


        // Debug NOTE by Mark, 06/02, 有再一層 DISTINCT 在我的 DB 裡 , 減少了一筆, 才和 MLASRS 吻合
        // 
        //        public static string V_P060 = @"
        //CREATE VIEW [dbo].[V_P060] AS 
        //SELECT a.WHSE_NO, a.STGE_TYPE, a.STGE_BIN, a.SU_ID, a.SU_TYPE, a.LOC_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.GTIN_QTY, a.SKU_UNIT, a.SKU_QTY, 
        //                  a.GTIN_NUMERATOR, a.GTIN_DENOMINATOR, a.GROSS_WEIGHT, a.NET_WEIGHT, a.WEIGHT_UNIT, a.VOLUME, a.VOLUME_UNIT, a.GTIN_ALO_QTY, a.SKU_ALO_QTY, a.REMARK, a.TRN_USER, a.TRN_DATE, a.CRT_USER, a.CRT_DATE, 
        //                  d.EQU_NO, d.LOC_STS
        //FROM     dbo.LOC_DTL AS a INNER JOIN
        //                  dbo.PLT_DTL AS b ON a.WHSE_NO = b.WHSE_NO AND a.PLANT = b.PLANT AND a.STGE_LOC = b.STGE_LOC AND a.SKU_NO = b.SKU_NO AND ISNULL(a.BATCH_NO, '') = ISNULL(a.BATCH_NO, '') AND ISNULL(a.STK_SPECIAL_IND, '') 
        //                  = ISNULL(b.STK_SPECIAL_IND, '') AND ISNULL(a.STK_SPECIAL_NO, '') = ISNULL(b.STK_SPECIAL_NO, '') AND a.GTIN_UNIT = b.GTIN_UNIT AND a.SU_ID = b.SU_ID INNER JOIN
        //                  dbo.IN_DTL AS c ON b.WHSE_NO = c.WHSE_NO AND b.IN_NO = c.IN_NO AND b.IN_LINE = c.IN_LINE INNER JOIN
        //                  dbo.LOC_MST AS d ON a.LOC_NO = d.LOC_NO AND a.SU_ID = d.SU_ID
        //WHERE  (a.STGE_TYPE = 'ATR') AND (d.LOC_STS = 'S') AND (a.GTIN_ALO_QTY = 0)
        //";
        public static string V_P060 = @"
            CREATE VIEW [dbo].[V_P060] AS 

                    select distinct T1.* from(

                    SELECT a.WHSE_NO, a.STGE_TYPE, a.STGE_BIN, a.SU_ID, a.SU_TYPE, a.LOC_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.GTIN_QTY, a.SKU_UNIT, a.SKU_QTY,
                                      a.GTIN_NUMERATOR, a.GTIN_DENOMINATOR, a.GROSS_WEIGHT, a.NET_WEIGHT, a.WEIGHT_UNIT, a.VOLUME, a.VOLUME_UNIT, a.GTIN_ALO_QTY, a.SKU_ALO_QTY, a.REMARK, a.TRN_USER, a.TRN_DATE, a.CRT_USER, a.CRT_DATE,
                                      d.EQU_NO, d.LOC_STS
                    FROM     dbo.LOC_DTL AS a INNER JOIN
                                      dbo.PLT_DTL AS b ON a.WHSE_NO = b.WHSE_NO AND a.PLANT = b.PLANT AND a.STGE_LOC = b.STGE_LOC AND a.SKU_NO = b.SKU_NO AND ISNULL(a.BATCH_NO, '') = ISNULL(a.BATCH_NO, '') AND ISNULL(a.STK_SPECIAL_IND, '')
                              = ISNULL(b.STK_SPECIAL_IND, '') AND ISNULL(a.STK_SPECIAL_NO, '') = ISNULL(b.STK_SPECIAL_NO, '') AND a.GTIN_UNIT = b.GTIN_UNIT AND a.SU_ID = b.SU_ID INNER JOIN
                              dbo.IN_DTL AS c ON b.WHSE_NO = c.WHSE_NO AND b.IN_NO = c.IN_NO AND b.IN_LINE = c.IN_LINE INNER JOIN
                              dbo.LOC_MST AS d ON a.LOC_NO = d.LOC_NO AND a.SU_ID = d.SU_ID
            WHERE  (a.STGE_TYPE = 'ATR') AND(d.LOC_STS = 'S') AND(a.GTIN_ALO_QTY = 0)

            )T1
";


        public static string V_P070 = @"
	   CREATE VIEW V_P070 AS 
select a.*,b.STGE_TYPE,b.STGE_BIN,b.LOC_NO,b.GTIN_NUMERATOR,b.GTIN_DENOMINATOR,b.GROSS_WEIGHT,b.NET_WEIGHT,b.WEIGHT_UNIT,b.VOLUME,b.VOLUME_UNIT,b.SKU_QTY as LOC_QTY
                    from PLT_DTL a join LOC_DTL b
                    on (a.SU_ID=b.SU_ID and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(b.BATCH_NO,'') and IsNull(a.STK_CAT,'')=IsNull(b.STK_CAT,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.SKU_UNIT=b.SKU_UNIT )
                      
";

        public static string V_R030 = @"
CREATE VIEW [dbo].[V_R030] AS 
select SUBSTRING(a.TRN_DATE,1,10) as TRN_DATE,a.SKU_NO,b.SKU_DESC,a.DATE_CODE,a.EXPIRE_DATE,a.BATCH_NO,CASE WHEN c.IN_SNO='**********' THEN '' ELSE c.IN_SNO END as IN_SNO,sum(c.SKU_RCV_QTY) as RCV_QTY,b.SKU_UNIT 
                from IN_DTL a join SKU_MST b on (a.SKU_NO=b.SKU_NO)
                join IN_SNO c on (a.WHSE_NO=c.WHSE_NO and a.IN_NO=c.IN_NO and a.IN_LINE=c.IN_LINE)
                group by SUBSTRING(a.TRN_DATE,1,10),a.SKU_NO,b.SKU_DESC,a.DATE_CODE,a.EXPIRE_DATE,a.BATCH_NO,c.IN_SNO,b.SKU_UNIT 
";

        public static string V_R040 = @"
create view [dbo].[V_R040] AS 
select  SUBSTRING(c.TRN_DATE,1,10) as DATE,c.SKU_NO,b.SKU_DESC,d.EXPIRE_DATE ,c.BATCH_NO,CASE WHEN c.IN_SNO='**********' THEN '' ELSE c.IN_SNO END as IN_SNO,c.GTIN_UNIT,sum(c.GTIN_FIN_QTY) as GTIN_QTY from PCK_SNO c 
join SKU_MST b on (c.SKU_NO=b.SKU_NO)
join IN_DTL d on (c.WHSE_NO=d.WHSE_NO and c.IN_NO=d.IN_NO and c.IN_LINE=d.IN_LINE)
group by SUBSTRING(c.TRN_DATE,1,10),c.SKU_NO,b.SKU_DESC,d.EXPIRE_DATE,c.BATCH_NO,c.IN_SNO,c.GTIN_UNIT
";

        public static string V_R050 = @"
CREATE VIEW [dbo].[V_R050] AS 
select  a.SKU_NO,b.SKU_DESC,a.GTIN_UNIT,a.BATCH_NO,a.LOC_NO,a.SU_ID,a.SU_TYPE,c.GTIN_MAX_QTY,sum(a.GTIN_QTY) as GTIN_QTY,CASE WHEN sum(a.GTIN_QTY)=c.GTIN_MAX_QTY THEN 'X' ELSE '' END as FULL_IND  from LOC_DTL a
 join SKU_MST b on (a.SKU_NO=b.SKU_NO) 
 join SKU_SUT c on (a.WHSE_NO=c.WHSE_NO and a.SKU_NO=c.SKU_NO and a.SU_TYPE=c.SU_TYPE and a.GTIN_UNIT=c.GTIN_UNIT)
 group by a.SKU_NO,b.SKU_DESC,a.GTIN_UNIT,a.BATCH_NO,a.LOC_NO,a.SU_ID,a.SU_TYPE,c.GTIN_MAX_QTY
";

        public static string V_R060 = @"
CREATE VIEW [dbo].[V_R060]
AS
SELECT SKU_NO, SKU_DESC, CAST(SUM(OUT_COUNT) AS int) AS Outbound, CAST(SUM(IN_COUNT) AS int) AS Inbound, CAST(SUM(TX_COUNT) AS int) AS Relocation, CAST(SUM(OUT_COUNT + IN_COUNT + TX_COUNT) AS int) AS Total
FROM     dbo.STOCK_MOVE_PLT
GROUP BY SKU_NO, SKU_DESC
";

        public static string V_R070 = @"
create view [dbo].[V_R070] AS
					select SKU_NO,SKU_DESC,sum(OUT_COUNT) as Outbound,sum(IN_COUNT) as Inbound,sum(TX_COUNT) as Relocation,
                    sum(OUT_COUNT+IN_COUNT+TX_COUNT) as Total from STOCK_MOVE_TRN group by SKU_NO,SKU_DESC
";

        public static string V_R080 = @"
CREATE VIEW [dbo].[V_R080]
AS
select a.PIC_NO,c.PIC_STS,a.SKU_NO,b.SKU_DESC,a.BATCH_NO,a.COUNT_UNIT,sum(a.GTIN_QTY) as GTIN_QTY,sum(a.COUNT_QTY) as COUNT_QTY,a.SU_ID,sum(a.COUNT_QTY)-sum(a.GTIN_QTY) as DIFF_QTY,c.COUNT_USER as COUNT_USER,c.APPROVE_USER 
                    from PIC_SNO a 
						join PIC_MST c on (a.PIC_NO=c.PIC_NO)
                        join SKU_MST b on (a.SKU_NO=b.SKU_NO)
                    where a.GTIN_QTY <> a.COUNT_QTY
					group by a.PIC_NO,c.PIC_STS,a.SKU_NO,b.SKU_DESC,a.BATCH_NO,a.COUNT_UNIT,c.COUNT_USER,a.SU_ID,c.APPROVE_USER 
";

        public static string v_table_list = @"
CREATE VIEW [dbo].[v_table_list]
AS
SELECT TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE
FROM     INFORMATION_SCHEMA.TABLES
";

        public static string V_USER_PROG_BY_GROUP = @"
CREATE VIEW [dbo].[V_USER_PROG_BY_GROUP]
AS
SELECT T2.USER_ID,T3.PROG_ID,T1.GROUP_ID , T3.ENABLE GROUP_WRT_ENABLE FROM	

GROUP_MST T1,
GROUP_DTL T2,
GROUP_WRT T3
WHERE T1.GROUP_ID= T2.GROUP_ID
AND T1.GROUP_ID =T3.GROUP_ID
AND T1.ENABLE ='Y'
AND T2.ENABLE ='Y'
AND T3.ENABLE ='Y'
";

        public static string v_user_role = @"
CREATE VIEW [dbo].[v_user_role]

AS 

SELECT T1.UserId, T2.UserName,  T1.RoleId, T4.Name AS RoleName
FROM     dbo.AspNetUserRoles AS T1 INNER JOIN
                  dbo.AspNetUsers AS T2 ON T1.UserId = T2.Id INNER JOIN
                  dbo.AspNetRoles AS T4 ON T1.RoleId = T4.Id 
";

        public static string V_RIGHT = @"
CREATE VIEW V_RIGHT AS
SELECT b.user_id ,a.*,
   Isnull(b.user_id, 'N')     AS UU,
   Isnull(b.query_wrt, 'N')   AS QUERY_WRT,
   Isnull(b.print_wrt, 'N')   AS PRINT_WRT,
   Isnull(b.import_wrt, 'N')  AS IMPORT_WRT,
   Isnull(b.export_wrt, 'N')  AS EXPORT_WRT,
   Isnull(b.update_wrt, 'N')  AS UPDATE_WRT,
   Isnull(b.delete_wrt, 'N')  AS DELETE_WRT,
   Isnull(b.approve_wrt, 'N') AS ARRROVE_WRT
FROM prog_mst a
JOIN prog_wrt b
  ON(a.prog_id = b.prog_id)
WHERE a.enable = 'Y'
  AND b.enable = 'Y'
";

        public static string V_P020_LocDtl = @"
create view V_P020_LocDtl as
select a.STGE_TYPE,a.STGE_BIN,a.WHSE_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.SKU_UNIT, a.SU_ID, a.SU_TYPE, a.LOC_NO, a.SKU_QTY, a.SKU_ALO_QTY, min(b.EXPIRE_DATE) as EXPIRE_DATE, min(b.GR_DATE) as GR_DATE,a.GTIN_NUMERATOR,a.GTIN_DENOMINATOR from LOC_DTL a join PLT_DTL b on (a.SU_ID=b.SU_ID and a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(b.BATCH_NO,'') and IsNull(a.STK_CAT,'')=IsNull(b.STK_CAT,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.SKU_UNIT=b.SKU_UNIT) join LOC_MST c on (a.LOC_NO=c.LOC_NO) where c.LOC_STS='S' and a.STGE_TYPE='ATR' and a.SKU_ALO_QTY=0 and a.WHSE_NO='DCR' and a.PLANT='DC01' and a.STGE_LOC='1010' and a.SKU_NO='10313667' and IsNull(a.BATCH_NO,'')='' and IsNull(a.STK_CAT,'')='' and IsNull(a.STK_SPECIAL_IND,'')='' and IsNull(a.STK_SPECIAL_NO,'')='' and a.SKU_UNIT='ZWF' group by a.STGE_TYPE,a.STGE_BIN,a.WHSE_NO, a.PLANT, a.STGE_LOC, a.SKU_NO, a.BATCH_NO, a.STK_CAT, a.STK_SPECIAL_IND, a.STK_SPECIAL_NO, a.GTIN_UNIT, a.SKU_UNIT, a.SU_ID, a.SU_TYPE, a.LOC_NO, a.SKU_QTY, a.SKU_ALO_QTY,a.GTIN_NUMERATOR,a.GTIN_DENOMINATOR 
";

        public static string V_P020_MergeOutDtl = @"
create view V_P020_MergeOutDtl AS 
select WHSE_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,SKU_UNIT,sum(SKU_OUT_QTY - SKU_ALO_QTY) as SKU_CMD_QTY from OUT_DTL where OUT_NO in (2000359162) and OUT_STS in ('0','1') and SKU_OUT_QTY > SKU_ALO_QTY group by WHSE_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,SKU_UNIT 
";

        public static string V_P020A = @"
create VIEW V_P020A AS
select WHSE_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,SKU_UNIT
,sum(SKU_OUT_QTY - SKU_ALO_QTY) as SKU_CMD_QTY 
from OUT_DTL 
where OUT_NO in (2000290796) and OUT_STS in ('0','1') and SKU_OUT_QTY > SKU_ALO_QTY 
group by WHSE_NO,PLANT,STGE_LOC,SKU_NO,BATCH_NO,STK_CAT,STK_SPECIAL_IND,STK_SPECIAL_NO,GTIN_UNIT,SKU_UNIT 
";

        public static string V_P020B = @"
CREATE VIEW V_P020B
AS
SELECT a.stge_type,
       a.stge_bin,
       a.whse_no,
       a.plant,
       a.stge_loc,
       a.sku_no,
       a.batch_no,
       a.stk_cat,
       a.stk_special_ind,
       a.stk_special_no,
       a.gtin_unit,
       a.sku_unit,
       a.su_id,
       a.su_type,
       a.loc_no,
       a.sku_qty,
       a.sku_alo_qty,
       Min(b.expire_date) AS EXPIRE_DATE,
       Min(b.gr_date)     AS GR_DATE,
       a.gtin_numerator,
       a.gtin_denominator
FROM   loc_dtl a
       JOIN plt_dtl b
         ON ( a.su_id = b.su_id
              AND a.whse_no = b.whse_no
              AND a.plant = b.plant
              AND a.stge_loc = b.stge_loc
              AND a.sku_no = b.sku_no
              AND Isnull(a.batch_no, '') = Isnull(b.batch_no, '')
              AND Isnull(a.stk_cat, '') = Isnull(b.stk_cat, '')
              AND Isnull(a.stk_special_ind, '') = Isnull(b.stk_special_ind, '')
              AND Isnull(a.stk_special_no, '') = Isnull(b.stk_special_no, '')
              AND a.sku_unit = b.sku_unit )
       JOIN loc_mst c
         ON ( a.loc_no = c.loc_no )
WHERE  c.loc_sts = 'S'
       AND a.stge_type = 'ATR'
       AND a.sku_alo_qty = 0
       AND a.whse_no = 'DCR'
       AND a.plant = 'DC01'
       AND a.stge_loc = '1010'
       AND a.sku_no = '10313274'
       AND Isnull(a.batch_no, '') = ''
       AND Isnull(a.stk_cat, '') = ''
       AND Isnull(a.stk_special_ind, '') = ''
       AND Isnull(a.stk_special_no, '') = ''
       AND a.sku_unit = 'EA'
GROUP  BY a.stge_type,
          a.stge_bin,
          a.whse_no,
          a.plant,
          a.stge_loc,
          a.sku_no,
          a.batch_no,
          a.stk_cat,
          a.stk_special_ind,
          a.stk_special_no,
          a.gtin_unit,
          a.sku_unit,
          a.su_id,
          a.su_type,
          a.loc_no,
          a.sku_qty,
          a.sku_alo_qty,
          a.gtin_numerator,
          a.gtin_denominator
";

        public static string V_P030 = @"
CREATE VIEW V_P030 AS
			 select b.WHSE_NO,b.OUT_NO,b.OUT_LINE,b.PLANT,b.STGE_LOC,b.SKU_NO,b.BATCH_NO,b.STK_CAT,b.STK_SPECIAL_IND,b.STK_SPECIAL_NO,b.GTIN_UNIT,b.GTIN_OUT_QTY,b.GTIN_ALO_QTY,b.SKU_UNIT,b.SKU_OUT_QTY,b.SKU_ALO_QTY,b.GROSS_WEIGHT,b.NET_WEIGHT,b.WEIGHT_UNIT,b.VOLUME,b.VOLUME_UNIT,b.GTIN_DESC,b.GTIN_NO,b.GTIN_NUMERATOR,b.GTIN_DENOMINATOR,b.REQM_NO,b.REQM_LINE,b.DOC_NO,b.DOC_LINE,b.MOVM_TYPE,b.SKU_GROUP,b.TP_GROUP,b.DD_LINE,b.CREATEUSER,b.CREATEDATE,b.CREATETIME,IsNull(sum(c.SKU_QTY-c.SKU_ALO_QTY),0) as SKU_AVAIL_QTY
                from OUT_MST a join OUT_DTL b on (a.OUT_NO=b.OUT_NO) 
                left join LOC_DTL c on (b.WHSE_NO=c.WHSE_NO and b.PLANT=c.PLANT and b.STGE_LOC=c.STGE_LOC and b.SKU_NO=c.SKU_NO and IsNull(b.BATCH_NO,'')=IsNull(c.BATCH_NO,'') and IsNull(b.STK_CAT,'')=IsNull(c.STK_CAT,'') and IsNull(b.STK_SPECIAL_IND,'')=IsNull(c.STK_SPECIAL_IND,'') and IsNull(b.STK_SPECIAL_NO,'')=IsNull(c.STK_SPECIAL_NO,'') and b.SKU_UNIT=c.SKU_UNIT)
                where a.SHIP_CONDITION not in ('20','90') and b.SKU_OUT_QTY > b.SKU_ALO_QTY

				group by b.WHSE_NO,b.OUT_NO,b.OUT_LINE,b.PLANT,b.STGE_LOC,b.SKU_NO,b.BATCH_NO,b.STK_CAT,b.STK_SPECIAL_IND,b.STK_SPECIAL_NO,b.GTIN_UNIT,b.GTIN_OUT_QTY,b.GTIN_ALO_QTY,b.SKU_UNIT,b.SKU_OUT_QTY,b.SKU_ALO_QTY,b.GROSS_WEIGHT,b.NET_WEIGHT,b.WEIGHT_UNIT,b.VOLUME,b.VOLUME_UNIT,b.GTIN_DESC,b.GTIN_NO,b.GTIN_NUMERATOR,b.GTIN_DENOMINATOR,b.REQM_NO,b.REQM_LINE,b.DOC_NO,b.DOC_LINE,b.MOVM_TYPE,b.SKU_GROUP,b.TP_GROUP,b.DD_LINE,b.CREATEUSER,b.CREATEDATE,b.CREATETIME 
";

        public static string V_P030SUB = @"
CREATE VIEW V_P030SUB
AS
select a.STGE_TYPE, a.STGE_BIN, a.SU_ID, a.LOC_NO, a.WHSE_NO, a.PLANT ,a.STGE_LOC ,a.SKU_NO ,a.BATCH_NO ,a.STK_CAT ,a.STK_SPECIAL_IND ,a.STK_SPECIAL_NO ,a.SKU_UNIT, a.SKU_QTY, a.SKU_ALO_QTY, min(b.EXPIRE_DATE) as EXPIRE_DATE,min(b.GR_DATE) as GR_DATE from LOC_DTL a join PLT_DTL b on (a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and a.BATCH_NO=b.BATCH_NO and a.STK_CAT=b.STK_CAT and a.STK_SPECIAL_IND=b.STK_SPECIAL_IND and a.STK_SPECIAL_NO=b.STK_SPECIAL_NO and a.SKU_UNIT=b.SKU_UNIT and a.SU_ID=b.SU_ID) 

--where a.WHSE_NO='DCR' and a.PLANT='DC01' and a.STGE_LOC='1010' and a.SKU_NO='10001343' and IsNull(a.BATCH_NO,'')='' and IsNull(a.STK_CAT,'')='' and IsNull(a.STK_SPECIAL_IND,'')=' ' and IsNull(a.STK_SPECIAL_NO,'')='' and a.SKU_UNIT='ZWF' 

group by a.STGE_TYPE, a.STGE_BIN, a.SU_ID, a.LOC_NO, a.WHSE_NO, a.PLANT ,a.STGE_LOC ,a.SKU_NO ,a.BATCH_NO ,a.STK_CAT ,a.STK_SPECIAL_IND ,a.STK_SPECIAL_NO ,a.SKU_UNIT, a.SKU_QTY, a.SKU_ALO_QTY, b.EXPIRE_DATE, b.GR_DATE 
--order by b.EXPIRE_DATE,b.GR_DATE,a.SKU_QTY
";

        public static string V_P080 = @"
CREATE VIEW V_P080 AS
select distinct a.*,d.SKU_SNO_IND from LOC_DTL a join PLT_DTL b on (a.WHSE_NO=b.WHSE_NO and a.PLANT=b.PLANT and a.STGE_LOC=b.STGE_LOC and a.SKU_NO=b.SKU_NO and IsNull(a.BATCH_NO,'')=IsNull(a.BATCH_NO,'') and IsNull(a.STK_SPECIAL_IND,'')=IsNull(b.STK_SPECIAL_IND,'') and IsNull(a.STK_SPECIAL_NO,'')=IsNull(b.STK_SPECIAL_NO,'') and a.GTIN_UNIT=b.GTIN_UNIT and a.SU_ID=b.SU_ID) join IN_DTL c on (b.WHSE_NO=c.WHSE_NO and b.IN_NO=c.IN_NO and b.IN_LINE=c.IN_LINE) join SKU_MST d on (a.SKU_NO=d.SKU_NO) where a.STGE_TYPE='ATR' 
--order by a.SKU_NO, a.SU_ID
";

        public static string V_P100 = @"
create view V_P100 AS
select EQU_NO,LOC_NO,SU_ID,CEILING(LEN(REMARK)/7.0) as PLT_CNT,REMARK from LOC_MST where LOC_STS='E'
";

        public static string V_TRANSLATE = @"
CREATE VIEW V_TRANSLATE AS 
SELECT * FROM TRANSLATE
WHERE TEXT LIKE '%REASON%'
";

        public static string SP_C030 = @"
CREATE PROCEDURE [dbo].[SP_C030] @PIC_NO nvarchar(30)
AS
select distinct a.* from PIC_DTL a
join LOC_DTL b on(a.SU_ID = b.SU_ID
and a.SKU_NO = b.SKU_NO
and a.BATCH_NO = b.BATCH_NO
and a.COUNT_UNIT = b.GTIN_UNIT)
where a.PIC_NO = @PIC_NO
order by a.PIC_LINE
";

        public static string SP_R040 = @"
CREATE PROCEDURE [dbo].[SP_R040]
 
 @DATE_FROM varchar(20),
@DATE_TO varchar(20)

AS
 
SELECT SUBSTRING(c.TRN_DATE,1,10) as DATE,c.SKU_NO,b.SKU_DESC,d.EXPIRE_DATE ,c.BATCH_NO,CASE WHEN c.IN_SNO='**********' THEN '' ELSE c.IN_SNO END as IN_SNO,c.GTIN_UNIT,sum(c.GTIN_FIN_QTY) as GTIN_QTY 
 from PCK_SNO c 
join SKU_MST b on (c.SKU_NO=b.SKU_NO)
join IN_DTL d on (c.WHSE_NO=d.WHSE_NO and c.IN_NO=d.IN_NO and c.IN_LINE=d.IN_LINE)
where c.TRN_DATE > @DATE_FROM and c.TRN_DATE < @DATE_TO
group by SUBSTRING(c.TRN_DATE,1,10),c.SKU_NO,b.SKU_DESC,d.EXPIRE_DATE,c.BATCH_NO,c.IN_SNO,c.GTIN_UNIT
order by SUBSTRING(c.TRN_DATE,1,10),c.SKU_NO 
";

        public static string SP_R050 = @"
CREATE PROCEDURE [dbo].[SP_R050]
AS
   select  a.SKU_NO,b.SKU_DESC,a.GTIN_UNIT,a.BATCH_NO,a.LOC_NO,a.SU_ID,a.SU_TYPE,c.GTIN_MAX_QTY,sum(a.GTIN_QTY) as GTIN_QTY,CASE WHEN sum(a.GTIN_QTY)=c.GTIN_MAX_QTY THEN 'X' ELSE '' END as FULL_IND  from LOC_DTL a
 join SKU_MST b on (a.SKU_NO=b.SKU_NO) 
 join SKU_SUT c on (a.WHSE_NO=c.WHSE_NO and a.SKU_NO=c.SKU_NO and a.SU_TYPE=c.SU_TYPE and a.GTIN_UNIT=c.GTIN_UNIT)
 group by a.SKU_NO,b.SKU_DESC,a.GTIN_UNIT,a.BATCH_NO,a.LOC_NO,a.SU_ID,a.SU_TYPE,c.GTIN_MAX_QTY
";

        public static string SP_R060 = @"
CREATE PROCEDURE [dbo].[SP_R060]
 
 @DATE_FROM varchar(20),
@DATE_TO varchar(20)

AS

delete STOCK_MOVE_PLT;
		insert into STOCK_MOVE_PLT

                            select a.SKU_NO,b.SKU_DESC,0 as OUT_COUNT,count(distinct a.SU_ID) as IN_COUNT,0 as TX_COUNT from IN_SNO a
                            join SKU_MST b on (a.SKU_NO=b.SKU_NO)
                             where a.SKU_FIN_QTY>0 and a.TRN_DATE> @DATE_FROM and a.TRN_DATE < @DATE_TO 
                             group by a.SKU_NO,b.SKU_DESC
                             UNION ALL
                            select a.SKU_NO,b.SKU_DESC,count(distinct a.SU_ID) as OUT_COUNT,0 as IN_COUNT,0 as TX_COUNT from PCK_SNO a
                            join SKU_MST b on (a.SKU_NO=b.SKU_NO)
                             where a.SKU_FIN_QTY>0 and a.TRN_DATE> @DATE_FROM and a.TRN_DATE < @DATE_TO 
                             group by a.SKU_NO,b.SKU_DESC
                             UNION ALL
                             select a.SKU_NO,b.SKU_DESC,0 as OUT_COUNT,0 as IN_COUNT,count(distinct TX_NO) as TX_COUNT from TX_LOG a
                            join SKU_MST b on (a.SKU_NO=b.SKU_NO)
                             where a.TX_DATE> @DATE_FROM and a.TX_DATE < @DATE_TO
                             group by a.SKU_NO,b.SKU_DESC
							 
							       select SKU_NO,SKU_DESC,sum(OUT_COUNT) as Outbound,sum(IN_COUNT) as Inbound,sum(TX_COUNT) as Relocation,sum(OUT_COUNT+IN_COUNT+TX_COUNT) as Total
                    from STOCK_MOVE_PLT group by SKU_NO,SKU_DESC
";

        public static string SP_R070 = @"
CREATE PROCEDURE [dbo].[SP_R070]
 
 @DATE_FROM varchar(20),
@DATE_TO varchar(20)

AS

delete STOCK_MOVE_TRN;
                insert into STOCK_MOVE_TRN
                            select a.SKU_NO,b.SKU_DESC,0 as OUT_COUNT,count(*) as IN_COUNT,0 as TX_COUNT from IN_SNO a
                            join SKU_MST b on (a.SKU_NO=b.SKU_NO)
                             where a.SKU_FIN_QTY>0 and a.TRN_DATE>@DATE_FROM and a.TRN_DATE < @DATE_TO
                             group by a.SKU_NO,b.SKU_DESC
                             UNION ALL
                            select a.SKU_NO,b.SKU_DESC,count(*) as OUT_COUNT,0 as IN_COUNT,0 as TX_COUNT from PCK_SNO a
                            join SKU_MST b on (a.SKU_NO=b.SKU_NO)
                             where a.SKU_FIN_QTY>0 and a.TRN_DATE>@DATE_FROM and a.TRN_DATE < @DATE_TO
                             group by a.SKU_NO,b.SKU_DESC
                             UNION ALL
                             select a.SKU_NO,b.SKU_DESC,0 as OUT_COUNT,0 as IN_COUNT,count(*) as TX_COUNT from TX_LOG a
                            join SKU_MST b on (a.SKU_NO=b.SKU_NO)
                             where a.TX_DATE>@DATE_FROM and a.TX_DATE < @DATE_TO
                             group by a.SKU_NO,b.SKU_DESC
							 
						
						select SKU_NO,SKU_DESC,sum(OUT_COUNT) as Outbound,sum(IN_COUNT) as Inbound
             ,sum(TX_COUNT) as Relocation,sum(OUT_COUNT+IN_COUNT+TX_COUNT) as Total from STOCK_MOVE_TRN
              group by SKU_NO,SKU_DESC
";


        public static string no_authorization_to_add = "no authorization to add"; //S050
        public static string no_authorization_to_remove = "no authorization to remove"; //S050
        public static string no_authorization_to_create = "no authorization to create";
        public static string no_authorization_to_export = "no authorization to export";
        public static string no_authorization_to_update = "no authorization to update";
        public static string no_authorization_to_delete = "no authorization to delete";
        public static string no_authorization_to_change = "no authorization to change";
        //no authorization to force cancel
        public static string no_authorization_to_force_cancel = "no authorization to force cancel"; //M070
        public static string no_authorization_to_force_end = "no authorization to force end"; //M070
        public static string finished_CMD_cant_force_cancel = "finished CMD can't force cancel."; //M070
        public static string finished_CMD_cant_force_end = "finished CMD can't force end."; //M070

        public static string no_authorization_to_execute = "no authorization to execute"; //P070
        public static string source_storage_unit_number_must_input = "source storage unit number must input"; //P070
        public static string destination_storage_unit_number_must_input = "destination storage unit number must input"; //P070
        public static string source_storage_unit_number_incorrect = "source storage unit number incorrect"; //P070
        public static string destination_storage_unit_number_incorrect = "destination storage unit number incorrect"; //P070
        public static string incorect_storage_unit_number = "incorect storage unit number"; //P070

        //P060

        public static string no_data_to_execute = "no data to execute";
        //if (Convert.ToString(dgvRow.Cells["STGE_TYPE"].Value) != "ATR") throw new Exception("can't transfer out the inventory that storage type is not ATR.");
        //if (Convert.ToString(dgvRow.Cells["LOC_STS"].Value) != "S") throw new Exception("can't transfer out the inventory that have reserved transfer command.");
        //if (Convert.ToDecimal(dgvRow.Cells["GTIN_ALO_QTY"].Value) > 0) throw new Exception("can't transfer out the inventory that have reserved picking order.");
        public static string cant_transfer_out_the_inventory_that_storage_type_is_not_ATR = "can't transfer out the inventory that storage type is not ATR";
        public static string cant_transfer_out_the_inventory_that_have_reserved_transfer_command = "can't transfer out the inventory that have reserved transfer command";
        public static string cant_transfer_out_the_inventory_that_have_reserved_picking_order = "can't transfer out the inventory that have reserved picking order";




        // from clsTool_2.cs
        public static string sKey = "22099478";
        public static string sIV = "35783280";
    }
}
