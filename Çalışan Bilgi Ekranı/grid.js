$.prototype.grid = function(oarams) {
    var tableHtml = "<table><thead><tr>";
    for(i = 0; i< params.columns.length;i++)
    {
         tableHtml += "<th>"+params.columns[i] + "</th>";
    }
     tableHtml += "</tr></thead><tbody>";
     for(i = 0; i< params.data.length;i++)
     {
        tableHtml += "<tr>";
        for(j = 0; j< params.columns.length;j++)
        {
            tableHtml += "<td";
            if(!params.data[i][params.columns[j]])
            {
                if(j == 1)
                {
                    tableHtml += " onclick = 'openLink(params.data[i][params.columns[j]],params.columns)' ";  
                }
                else if(j == 2)
                {
                    tableHtml += " onclick = 'openMobile(params.data[i][params.columns[j]],params.columns)' ";  
                }
                tableHtml += ">";
                if(j == 9)
                {
                    tableHtml += " <a onclick = 'shuffleRecord(params.data[i][params.columns[j]],params.columns)'> <img src='plus.ico' /></a>" ;  
                }
                tableHtml += params.data[i][params.columns[j]];
            }
            tableHtml += "</td>";
        }
        tableHtml += "</tr>";
     }
     tableHtml += "</tbody></table>";
    this.append(tableHtml);
  };

  var openLink = function(item,columns) {};

  var openMobile = function(item,columns) {  };

  var shuffleRecord = function(item,columns) {  };