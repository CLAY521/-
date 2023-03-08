USE [kf_imow]
GO

/****** Object:  StoredProcedure [dbo].[proc_SearchBatchInvoice]    Script Date: 2023/1/11 9:14:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



---������������Ʊ�洢����
Create PROC [dbo].[proc_SearchOrderInvoiceV2]
    @PageSize INT = 10 ,--ÿҳ��������¼
    @PageIndex INT = 1 , --ָ����ǰΪ�ڼ�ҳ
    @OrderCode VARCHAR(32) = '' , --������
    @Account VARCHAR(40) = '' , --��Ա�˺�
    @Company VARCHAR(200) = '' , --��˾����
    @StartTime VARCHAR(50) = '' , --�µ�ʱ�䣨��ʼ��
    @EndTime VARCHAR(50) = '' --�µ�ʱ�䣨��ֹ��
AS
    BEGIN
        DECLARE @StartRecord INT;
        DECLARE @EndRecord INT; 
        DECLARE @SqlString NVARCHAR(3000);  
        DECLARE @WhereString VARCHAR(1000);
        DECLARE @CountString VARCHAR(2000);
        SET @WhereString = '';
        SET @StartRecord = ( @PageIndex - 1 ) * @PageSize + 1;
        SET @EndRecord = @PageIndex * @PageSize;

        SELECT  *
        INTO    #temp1
        FROM    ( SELECT    ISNULL(a.OrderCode, '') AS OrderCode ,
							a.createTime,
                            ISNULL(a.Account, '') AS Account ,
                            ISNULL(e.Company, '') AS Company ,
                            CASE WHEN i.InvoiceType = 1 THEN '��ֵ˰��Ʊ'
                                 ELSE '��ͨ��Ʊ'
                            END AS invoiceType ,
							
                            i.Company AS InvoiceCompany ,
                            i.IdentificationCode ,
                            i.RegisterFullAddr + i.RegisterAddress AS RegisterAddress ,
                            i.RegisterTelephone ,
                            i.Bank ,
                            i.BankAccount ,
                            i.Linkman ,
                            i.Mobile,
							c.Name AS shopName
                  FROM      ecOrderV2 a
                            left JOIN ecShop c ON a.ShopId = c.ID
							left JOIN ecUserInvoice i ON a.InvoiceId = i.ID
                            left JOIN ecUserFK j ON a.UserId = j.UserId 
							left JOIN ecUserInfo e ON e.ID = j.InfoId
                ) aa

        SET @SqlString = '(SELECT row_number() over (order by t1.CreateTime DESC) as RowId, t1.OrderCode,t1.Account,t1.Company,
	t1.ShopName,t1.CreateTime,t1.InvoiceType,t1.InvoiceCompany,t1.IdentificationCode,t1.RegisterAddress,t1.RegisterTelephone,t1.Bank,t1.BankAccount,
	t1.LinkMan,t1.Mobile
	FROM #temp1 t1 WHERE 1=1';
        IF @OrderCode IS NOT NULL
            AND @OrderCode != ''
            BEGIN
                SET @WhereString = @WhereString + ' and t1.OrderCode like ''%'
                    + @OrderCode + '%'' ';
            END;
	
        IF @Account IS NOT NULL
            AND @Account != ''
            BEGIN
                SET @WhereString = @WhereString + ' and t1.Account like ''%'
                    + @Account + '%'' ';
            END; 
        IF @Company IS NOT NULL
            AND @Company != ''
            BEGIN
                SET @WhereString = @WhereString + ' and t1.Company like ''%'
                    + @Company + '%'' ';
            END; 
        IF @StartTime IS NOT NULL
            AND @StartTime != ''
            BEGIN
                SET @WhereString = @WhereString + ' and t1.CreateTime > '''
                    + @StartTime + ''' ';
            END; 
        IF @EndTime IS NOT NULL
            AND @EndTime != ''
            BEGIN
                SET @WhereString = @WhereString + ' and t1.CreateTime < '''
                    + @EndTime + ''' ';
            END; 



        SET @SqlString = @SqlString + @WhereString;
        SET @SqlString = 'select * from ' + @SqlString
            + ') as t where rowId between ' + LTRIM(STR(@StartRecord))
            + ' and ' + LTRIM(STR(@EndRecord));

        SET @CountString = 'SELECT count(*) FROM #temp1 t1 
	WHERE 1=1';
        SET @CountString = @CountString + @WhereString;

	
        EXEC(@SqlString);
	
        EXEC(@CountString);

    END;

GO