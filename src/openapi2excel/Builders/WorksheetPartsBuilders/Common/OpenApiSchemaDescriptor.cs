using ClosedXML.Excel;
using Microsoft.OpenApi.Models;
using openapi2excel.core.Common;

namespace openapi2excel.core.Builders.WorksheetPartsBuilders.Common;

internal class OpenApiSchemaDescriptor(IXLWorksheet worksheet, OpenApiDocumentationOptions options)
{
   public int AddNameHeader(RowPointer actualRow, int startColumn)
      => worksheet.Cell(actualRow, startColumn).SetTextBold("이름").GetColumnNumber();

   public int AddNameValue(string name, int actualRow, int startColumn)
      => worksheet.Cell(actualRow, startColumn).SetText(name).GetColumnNumber();

   public int AddSchemaDescriptionHeader(RowPointer actualRow, int startColumn)
   {
      var cell = worksheet.Cell(actualRow, startColumn).SetTextBold("타입")
         .CellRight().SetTextBold("객체 타입")
         .CellRight().SetTextBold("형식")
         .CellRight().SetTextBold("길이")
         .CellRight().SetTextBold("필수 여부")
         .CellRight().SetTextBold("널 가능 여부")
         .CellRight().SetTextBold("길이")
         .CellRight().SetTextBold("패턴")
         .CellRight().SetTextBold("열거형")
         .CellRight().SetTextBold("사용 중단 여부")
         .CellRight().SetTextBold("기본값")
         .CellRight().SetTextBold("예제")
         .CellRight().SetTextBold("설명");

      return cell.GetColumnNumber();
   }

   public int AddSchemaDescriptionValues(OpenApiSchema schema, bool required, RowPointer actualRow, int startColumn, string? description = null, bool includeArrayItemType = false )
   {
      if (schema.Items != null && includeArrayItemType)
      {
         var cell = worksheet.Cell(actualRow, startColumn).SetText("array")
            .CellRight().SetText(schema.GetObjectDescription())
            .CellRight().SetText(schema.Items.Type)
            .CellRight().SetText(schema.Items.Format)
            .CellRight().SetText(schema.GetPropertyLengthDescription()).SetHorizontalAlignment(XLAlignmentHorizontalValues.Center)
            .CellRight().SetText(options.Language.Get(required)).SetHorizontalAlignment(XLAlignmentHorizontalValues.Center)
            .CellRight().SetText(options.Language.Get(schema.Nullable)).SetHorizontalAlignment(XLAlignmentHorizontalValues.Center)
            .CellRight().SetText(schema.GetPropertyRangeDescription()).SetHorizontalAlignment(XLAlignmentHorizontalValues.Center)
            .CellRight().SetText(schema.Items.Pattern)
            .CellRight().SetText(schema.Items.GetEnumDescription())
            .CellRight().SetText(options.Language.Get(schema.Deprecated)).SetHorizontalAlignment(XLAlignmentHorizontalValues.Center)
            .CellRight().SetText(schema.GetExampleDescription())
            .CellRight().SetText((string.IsNullOrEmpty(schema.Description) ? description : schema.Description).StripHtmlTags());

         return cell.GetColumnNumber();
      }
      else
      {
         var cell = worksheet.Cell(actualRow, startColumn).SetText(schema.GetTypeDescription())
            .CellRight().SetText(schema.GetObjectDescription())
            .CellRight().SetText(schema.Format)
            .CellRight().SetText(schema.GetPropertyLengthDescription()).SetHorizontalAlignment(XLAlignmentHorizontalValues.Center)
            .CellRight().SetText(options.Language.Get(required)).SetHorizontalAlignment(XLAlignmentHorizontalValues.Center)
            .CellRight().SetText(options.Language.Get(schema.Nullable)).SetHorizontalAlignment(XLAlignmentHorizontalValues.Center)
            .CellRight().SetText(schema.GetPropertyRangeDescription()).SetHorizontalAlignment(XLAlignmentHorizontalValues.Center)
            .CellRight().SetText(schema.Pattern)
            .CellRight().SetText(schema.GetEnumDescription())
            .CellRight().SetText(options.Language.Get(schema.Deprecated)).SetHorizontalAlignment(XLAlignmentHorizontalValues.Center)
            .CellRight().SetText(schema.GetDefaultDescription())
            .CellRight().SetText(schema.GetExampleDescription())
            .CellRight().SetText((string.IsNullOrEmpty(schema.Description) ? description : schema.Description).StripHtmlTags());

            return cell.GetColumnNumber();
      }
   }
}