using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelHelper
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Excel转DataTable
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            DataTable dt = new DataTable();
            string xlsType = "2003";
            string ext = Path.GetExtension(filePath);
            if (".xls".Equals(ext))
            {
                xlsType = "2003";
            }
            else if (".xlsx".Equals(ext))
            {
                xlsType = "2007";
            }
            else
            {
                return null;
            }

            ISheet sheet = null;
            if ("2007".Equals(xlsType))
            {
                XSSFWorkbook xssfworkbook;
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    xssfworkbook = new XSSFWorkbook(file);
                }
                sheet = xssfworkbook.GetSheetAt(0);
            }
            else if ("2003".Equals(xlsType))
            {
                HSSFWorkbook hssfworkbook;
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);
                }
                sheet = hssfworkbook.GetSheetAt(0);
            }

            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null)
                {
                    continue;
                }
                DataRow dataRow = dt.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }


        /// <summary>
        /// Excel转DataTable
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        //public static DataTable ExcelToDataTable(ZipArchiveEntry excelArchive)
        //{

        //    DataTable dt = new DataTable();
        //    string xlsType = "2003";
        //    string ext = Path.GetExtension(excelArchive.Name);
        //    if (".xls".Equals(ext))
        //    {
        //        xlsType = "2003";
        //    }
        //    else if (".xlsx".Equals(ext))
        //    {
        //        xlsType = "2007";
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //    ISheet sheet = null;
        //    using (Stream excelStream = excelArchive.Open())
        //    {
        //        if (".xls".Equals(ext))
        //        {
        //            var xssfworkbook = new XSSFWorkbook(excelStream);
        //            sheet = xssfworkbook.GetSheetAt(0);
        //        }
        //        else if (".xlsx".Equals(ext))
        //        {
        //            var workbook = new XSSFWorkbook(excelStream);
        //            sheet = workbook.GetSheetAt(0);
        //        }
        //    }

        //    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
        //    IRow headerRow = sheet.GetRow(0);
        //    int cellCount = headerRow.LastCellNum;
        //    for (int j = 0; j < cellCount; j++)
        //    {
        //        ICell cell = headerRow.GetCell(j);
        //        dt.Columns.Add(cell.ToString());
        //    }
        //    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
        //    {
        //        IRow row = sheet.GetRow(i);
        //        if (row == null)
        //        {
        //            continue;
        //        }
        //        DataRow dataRow = dt.NewRow();
        //        for (int j = row.FirstCellNum; j < cellCount; j++)
        //        {
        //            if (row.GetCell(j) != null)
        //                dataRow[j] = row.GetCell(j).ToString();
        //        }
        //        dt.Rows.Add(dataRow);
        //    }
        //    return dt;
        //}

        public static ColumnMapping BuildColMapping(string excelName, string colName, int? colIndex = null)
        {
            return colIndex.HasValue
                ? new ColumnMapping(excelName, colIndex.Value)
                : new ColumnMapping(excelName, colName);
        }

        public static MemoryStream RenderDataTableToExcel(DataTable dt, string[] headList = null,
            int startIndex = 0)
        {
            List<ColumnMapping> columnMapping = null;
            if (headList != null && headList.Any())
            {
                columnMapping = new List<ColumnMapping>();
                for (int i = 0; i < headList.Length; i++)
                {
                    columnMapping.Add(BuildColMapping(headList[i], "", i + startIndex));
                }
            }
            return RenderDataTableToExcel(dt, columnMapping);
        }


        /// <summary>
        /// 將DataTable轉成Stream輸出.
        /// </summary>
        /// <param name="sourceTable">The source table.</param>
        /// <param name="colMapping">可以为null</param>
        /// <returns></returns>
        public static MemoryStream RenderDataTableToExcel(DataTable sourceTable, List<ColumnMapping> colMapping = null)
        {
            var dtColumns = sourceTable.Columns;
            if (colMapping == null || !colMapping.Any())
            {
                colMapping = new List<ColumnMapping>();
                foreach (DataColumn item in dtColumns)
                {
                    colMapping.Add(new ColumnMapping(item.ColumnName, item.Ordinal));
                }
            }
            else
            {
                colMapping.ForEach(f =>
                {
                    if (!f.ColIndex.HasValue)
                    {
                        f.ColIndex = dtColumns.IndexOf(f.ColName);
                    }
                });
            }

            //列名
            var headerNames = colMapping.Select(f => f.ExcelColName).ToArray();
            var book = CreateHSSfWorkBook(headerNames);
            ICellStyle cellStyle = CreateCellStyle(book);
            var sheet = book.GetSheetAt(0);
            //数据
            var colIndexs = colMapping.Select(f => f.ColIndex).ToArray();
            int rowIndex = 1;
            foreach (DataRow row in sourceTable.Rows)
            {
                IRow dataRow = CreateRow(sheet, rowIndex, 20);
                int j = 0;
                foreach (var colIndex in colIndexs)
                {
                    ICell cell = dataRow.CreateCell(j, CellType.String);
                    cell.SetCellValue(row.ItemArray[colIndex.Value].ToString());
                    cell.CellStyle = cellStyle;
                    j++;
                }
                rowIndex++;
            }
            MemoryStream ms = new MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static IRow CreateRow(ISheet sheet, int index, float height = 20)
        {
            IRow dataRow = sheet.CreateRow(index);
            dataRow.HeightInPoints = height;
            return dataRow;
        }

        public static ICellStyle CreateCellStyle(HSSFWorkbook hssfworkbook, bool isHead = false)
        {
            ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            cellStyle.Alignment = HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            //有边框
            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;
            cellStyle.BorderTop = BorderStyle.Thin;
            if (isHead)
            {
                //表头样式
                cellStyle.FillPattern = FillPattern.SolidForeground;
                cellStyle.FillForegroundColor = HSSFColor.Grey40Percent.Index;
                IFont font = hssfworkbook.CreateFont();
                font.Color = HSSFColor.White.Index;
                cellStyle.SetFont(font);
            }
            return cellStyle;
        }


        /// <summary>
        /// 將DataTable轉成Stream輸出.
        /// </summary>
        /// <param name="SourceTable">The source table.</param>
        /// <returns></returns>
        public static Stream DataTableToExcel(DataTable SourceTable, string[] headName)
        {
            var workbook = new HSSFWorkbook();
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            dsi.Company = "EP";
            si.Author = "EP-IT";
            si.Comments = "EP-IT";
            workbook.SummaryInformation = si;
            workbook.DocumentSummaryInformation = dsi;

            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);

            // handling header.
            foreach (DataColumn column in SourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in SourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }

                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;
        }

        /// <summary>
        /// 创建wookbook 带头部
        /// </summary>
        /// <param name="excelNameArray"></param>
        /// <returns></returns>
        public static HSSFWorkbook CreateHSSfWorkBook(string[] excelNameArray)
        {
            HSSFWorkbook book = new HSSFWorkbook();

            ISheet sheet = book.CreateSheet();
            IRow headRow = CreateRow(sheet, 0, 40);
            ICellStyle cellStyle = CreateCellStyle(book, true);
            int colWidth = 30 * 256;
            //列名
            for (int i = 0; i < excelNameArray.Length; i++)
            {
                CreateICell(headRow, i, excelNameArray[i], cellStyle);
                sheet.SetColumnWidth(i, colWidth);
            }
            return book;
        }


        /// <summary>
        /// Excel转DataTable
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        /// <param name="headName"></param>
        /// <returns></returns>
        public static DataTable WebExcelToDataTable(string filePath, Stream content, out string[] headName)
        {
            headName = new string[0];
            DataTable dt = new DataTable();
            string xlsType = "2003";
            if (filePath.Contains(".xlsx"))
            {
                xlsType = "2007";
            }
            else if (filePath.Contains(".xls"))
            {
                xlsType = "2003";
            }
            else
            {
                return null;
            }

            ISheet sheet = null;
            if ("2007".Equals(xlsType))
            {
                XSSFWorkbook xssfworkbook;
                MemoryStream mem = new MemoryStream();

                using (var requestStream = content)
                {
                    byte[] buf = new byte[1024];
                    using (mem)
                    {
                        var len = 0;
                        while ((len = requestStream.Read(buf, 0, 1024)) != 0)
                        {
                            mem.Write(buf, 0, len);
                        }
                        mem.Position = 0;
                        xssfworkbook = new XSSFWorkbook(mem);
                    }
                }
                sheet = xssfworkbook.GetSheetAt(0);
            }
            else if ("2003".Equals(xlsType))
            {
                HSSFWorkbook hssfworkbook;
                MemoryStream mem = new MemoryStream();
                using (var requestStream = content)
                {
                    byte[] buf = new byte[1024];
                    using (mem)
                    {
                        var len = 0;
                        while ((len = requestStream.Read(buf, 0, 1024)) != 0)
                        {
                            mem.Write(buf, 0, len);
                        }
                        hssfworkbook = new HSSFWorkbook(mem);
                    }
                }
                sheet = hssfworkbook.GetSheetAt(0);
            }

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            headName = headerRow.Cells.Select(f => f.StringCellValue).ToArray();
            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                bool emptyRow = true;
                object[] itemArray = null;

                if (row != null && row.Cells.Count > 0)
                {
                    itemArray = new object[row.LastCellNum];

                    for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                    {

                        if (row.GetCell(j) != null)
                        {

                            switch (row.GetCell(j).CellType)
                            {
                                case CellType.Numeric:
                                    if (HSSFDateUtil.IsCellDateFormatted(row.GetCell(j))) //日期类型
                                    {
                                        itemArray[j] = row.GetCell(j).DateCellValue.ToString("yyyy/MM/dd");
                                    }
                                    else //其他数字类型
                                    {
                                        itemArray[j] = row.GetCell(j).NumericCellValue;
                                    }
                                    break;
                                case CellType.Blank:
                                    itemArray[j] = string.Empty;
                                    break;
                                case CellType.Formula:
                                    itemArray[j] = row.GetCell(j).StringCellValue;
                                    break;
                                default:
                                    itemArray[j] = row.GetCell(j).StringCellValue;
                                    break;
                            }
                            if (itemArray[j] != null && !string.IsNullOrEmpty(itemArray[j].ToString().Trim()))
                            {
                                emptyRow = false;
                            }
                        }
                    }
                }
                //非空数据行数据添加到DataTable
                if (!emptyRow)
                {
                    dt.Rows.Add(itemArray);
                }
            }
            return dt;
        }

        public static ICell CreateICell(IRow row, int index, string cellValue, ICellStyle cellStyle)
        {
            ICell cell = row.CreateCell(index, CellType.String);
            cell.CellStyle = cellStyle;
            cell.SetCellValue(cellValue);
            return cell;

        }

        //循环去除datatable中的空行
        public static void RemoveEmpty(DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool rowdataisnull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {

                        rowdataisnull = false;
                    }

                }
                if (rowdataisnull)
                {
                    removelist.Add(dt.Rows[i]);
                }

            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
        }

        public static string[] GetHeadName(DataTable dt)
        {
            string[] headName = null;
            if (dt.Columns.Count > 0)
            {
                int columnNum = 0;
                columnNum = dt.Columns.Count;
                headName = new string[columnNum];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    headName[i] = dt.Columns[i].ColumnName;
                }
            }

            return headName;
        }

        public class ColumnMapping
        {
            public ColumnMapping(string excelColName, string colName)
            {
                ExcelColName = excelColName;
                ColName = colName;
            }
            public ColumnMapping(string excelColName, int colIndex)
            {
                ExcelColName = excelColName;
                ColIndex = colIndex;
            }
            /// <summary>
            /// EXCEL显示的列名
            /// </summary>
            public string ExcelColName { get; set; }
            /// <summary>
            /// 数据列的列名
            /// </summary>
            public string ColName { get; set; }
            /// <summary>
            /// 数据列的索引 根据ColName得到索引
            /// </summary>
            public int? ColIndex { get; set; }
        }
    }
}
