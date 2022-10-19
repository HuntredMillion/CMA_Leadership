var editor;

$(document).ready(function () {
    editor = new $.fn.dataTable.Editor({
        $.ajax(
            {
                url: '/Test/AjaxMethod',
                type: "POST",
                dataType: "JSON",
                dataSrc: function (json) {
                    // Settings.
                    jsonObj = $.parseJSON(json.data) 

                    // Data
                    return jsonObj.data;
                }
            }),
        table: "#demoGrid",
        fields: [{
            label: "First name:",
            name: "first_name"
        }, {
            label: "Last name:",
            name: "last_name"
        }, {
            label: "Current Position:",
            name: "Current_Position"
        }, {
            label: "Current Rank:",
            name: "Current_Rank"
        }
        ]
    });

    // Activate an inline edit on click of a table cell
    $('#demoGrid').on('click', 'tbody td.editable', function (e) {
        editor.inline(this);
    });

    $('#demoGrid').DataTable({
        dom: 'Bfrtip',
        ajax:
        {
            url: '/Test/AjaxMethod',
            type: "POST",
            dataType: "JSON",
            dataSrc: function (json) {
                // Settings.
                jsonObj = $.parseJSON(json.data)

                // Data
                return jsonObj.data;
            }
        },
        columns: [
            {
                data: null,
                defaultContent: '',
                className: 'select-checkbox',
                orderable: false
            },
            { data: 'StudentId' },
            { data: 'first_name', className: 'editable' },
            { data: 'last_name', className: 'editable' },
            { data: 'Years_Attended' },
            { data: 'Division' },
            { data: 'Current_Position', editField: "positions.site" }
                { data: 'Current_Rank', className: 'editable' }
                { data: 'Unit' },
        ],
        select: {
            style: 'os',
            selector: 'td:first-child'
        },
        buttons: [
            { extend: 'create', editor: editor },
            { extend: 'edit', editor: editor },
            { extend: 'remove', editor: editor }
        ]
    });

});