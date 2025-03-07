using ClosedXML.Excel;
using Microsoft.OpenApi.Models;
using openapi2excel.core.Builders.WorksheetPartsBuilders.Common;
using openapi2excel.core.Common;

namespace openapi2excel.core.Builders.WorksheetPartsBuilders;

internal class RequestParametersBuilder(
   RowPointer actualRow,
   int attributesColumnIndex,
   IXLWorksheet worksheet,
   OpenApiDocumentationOptions options)
   : WorksheetPartBuilder(actualRow, worksheet, options)
{
   private readonly OpenApiSchemaDescriptor _schemaDescriptor = new(worksheet, options);

   public void AddRequestParametersPart(OpenApiOperation operation)
   {
      attributesColumnIndex = attributesColumnIndex > 1 ? attributesColumnIndex : 2;
      if (!operation.Parameters.Any())
         return;

      Cell(1).SetTextBold("매개변수 (파라미터)");
      ActualRow.MoveNext();
      using (var _ = new Section(Worksheet, ActualRow))
      {
         var nextCell = Cell(1).SetTextBold("이름")
            .CellRight(attributesColumnIndex - 1).SetTextBold("파라미터 종류")
            .CellRight().SetTextBold("직렬화 방식")
            .CellRight();

         var lastUsedColumn = _schemaDescriptor.AddSchemaDescriptionHeader(ActualRow, nextCell.Address.ColumnNumber);

         Cell(1).SetBackground(lastUsedColumn, HeaderBackgroundColor)
            .SetBottomBorder(lastUsedColumn);

         ActualRow.MoveNext();
         foreach (var operationParameter in operation.Parameters)
         {
            AddPropertyRow(operationParameter);
         }
         ActualRow.MovePrev();
      }

      ActualRow.MoveNext(2);
   }

   private void AddPropertyRow(OpenApiParameter parameter)
   {
      var nextCell = Cell(1).SetText(parameter.Name)
         .CellRight(attributesColumnIndex - 1).SetText(parameter.In.ToString()?.ToUpper())
         .CellRight().SetText(parameter.Style?.ToString())
         .CellRight();

      _schemaDescriptor.AddSchemaDescriptionValues(parameter.Schema, parameter.Required, ActualRow, nextCell.Address.ColumnNumber, parameter.Description, true );
      ActualRow.MoveNext();
   }
}