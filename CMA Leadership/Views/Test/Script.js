
debugger;
Positions = ["SL", "TL", "DRUM MAJ.", "UC", "PL", "PS", "XO", "SQAD ATHL", "MnA OFFICER", "AIDE ADMIN", "REG ADJ", "SQUAD ADJ", "DIV", "UNIT NCO", "1ST SGT", "OPS", "AIDE OPS", "MnA NCO", "RSM"];
$(document).ready(function () {




    var table = $('#demoGrid').DataTable(
        {

            "dom": "Bfrtip",
            "processing": true, // for show progress bar
            "serverSide": false, //for large amounts of data. Doesn't work here though
            "ajax": {
                "url": "/Test/AjaxLoad",
                "type": "POST",

                "datatype": "json",
                "dataSrc": "",

            },

            "columns": [
                { "data": 'studentId' },
                { "data": 'first_Name' },
                { "data": 'last_Name' },
                { "data": 'years_Attended' },
                { "data": 'division' },
                { "data": 'current_Position', "name": 'Position' },
                { "data": 'current_Rank', "name": 'current_Rank' },
                { "data": 'unit' },
            ],
            //"buttons": [
            //    {
            //        "text": "View",
            //        "id": "DataView",
            //        action: function (e, dt, node, config) {
            //            if (this.text() === "View"){
            //                //alert('View activated');
            //                this.text("Edit")
            //                this.disable();
            //                buttons(1).disable();
            //            }
            //            else{
            //                    alert('Edit activated');
            //                    this.text("View")
            //            }
            //        }

            //    },
            //    {
            //            "text": "No",
            //            "id": "Nope",
            //    }
            //]      
        });

    table.button().add(0, {
        "text": "View",

        action: function (e, dt, node, config) {
            alert('View activated');
            this.disable();
            table.button(1).enable();
        },
        "enabled": false
    });
    table.button().add(1, {
        "text": "Edit",
        action: function (e, dt, node, config) {
            alert('Edit activated');
            this.disable();
            table.button(0).enable();
        }
    });

});




// Activate an inline edit on click of a table cell
$('#demoGrid').on('click', 'td', function () {
    //alert('Data:' + $(this).html().trim());
    //alert('Row:' + $(this).parent().find('td').html().trim());
    const CName = $('#demoGrid thead tr th').eq($(this).index()).html().trim()
    //alert('Column:' + CName);

    ////var data = table.row(this).data();
    ////alert('You clicked on ' + data[0] + "'s row");
    ////console.log("you clicked on" + data[0])

    if (CName === "Current_Position") {
        //console.log('TD cell textContent : ', this.textContent)
        //console.log('TD cell textContent : ', this.textContent)
        var thisCell = table.cell(this);
        //console.log(thisCell.data());
        thisCell.data($("<select></select>", {
            "class": "updatePosition"
        }).append(Positions.map(v => $("<option></option>", {
            "text": v,
            "value": v,
            "selected": (v === thisCell.data())
        }))).prop("outerHTML"));
    }
});

$('#demoGrid tbody').on("change", ".changePosition", () => {
    table.cell($(".changePosition").parents('td')).data($(".changePosition").val());
    //$('#demoGrid').removeClass("editing");
});
