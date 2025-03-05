using ClosedXML.Excel;
using Microsoft.OpenApi.Models;
using openapi2excel.core.Builders.WorksheetPartsBuilders.Common;
using openapi2excel.core.Common;

namespace openapi2excel.core.Builders.WorksheetPartsBuilders;

internal class OperationInfoBuilder(
   RowPointer actualRow,
   int attributesColumnIndex,
   IXLWorksheet worksheet,
   OpenApiDocumentationOptions options)
   : WorksheetPartBuilder(actualRow, worksheet, options)
{
   public void AddOperationInfoSection(string path, OpenApiPathItem pathItem, OperationType operationType,
      OpenApiOperation operation)
   {
      Cell(1).SetTextBold("요청 정보");
      ActualRow.MoveNext();

      using (var _ = new Section(Worksheet, ActualRow))
      {
         var cell = Cell(1).SetTextBold("요청 유형").CellRight(attributesColumnIndex).SetText(operationType.ToString().ToUpper())
            .IfNotEmpty(operation.OperationId, c => c.NextRow().SetTextBold("Id").CellRight(attributesColumnIndex).SetText(operation.OperationId))
            .NextRow().SetTextBold("엔드포인트 경로").CellRight(attributesColumnIndex).SetText(path)
            .IfNotEmpty(pathItem.Description, c => c.NextRow().SetTextBold("엔드포인트 경로 설명").CellRight(attributesColumnIndex).SetText(pathItem.Description))
            .IfNotEmpty(pathItem.Summary, c => c.NextRow().SetTextBold("엔드포인트 경로 요약").CellRight(attributesColumnIndex).SetText(pathItem.Summary))
            .IfNotEmpty(operation.Description, c => c.NextRow().SetTextBold("요청 설명").CellRight(attributesColumnIndex).SetText(operation.Description))
            .IfNotEmpty(operation.Summary, c => c.NextRow().SetTextBold("요청 요약").CellRight(attributesColumnIndex).SetText(operation.Summary))
            .NextRow().SetTextBold("사용 중단 여부").CellRight(attributesColumnIndex).SetText(Options.Language.Get(operation.Deprecated));

         ActualRow.GoTo(cell.Address.RowNumber);
      }

      ActualRow.MoveNext(2);
   }
}