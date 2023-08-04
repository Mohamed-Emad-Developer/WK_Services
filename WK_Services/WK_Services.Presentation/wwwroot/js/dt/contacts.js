function contactsTable(url, clientId) {

    let table = $('#my_dt').DataTable({
        processing: true,
        destroy: true,
        orderCellsTop: true,
        autoWidth: false,
        deferRender: true,
        lengthMenu: [10, 25, 50, 1000],
        ajax: {
            type: "POST",
            url: url,
            data: { clientId: clientId },
            datatype: "json"

        },
        columns: [
            { data: "name", title: 'Name' },
            { data: "mobile", title: 'Mobile' },
            { data: "email", title: 'Email Address' },
            { data: "userName", title: 'User Name' },
            {
                data: "id",
                title: '',
                render: function (data, type, row) {
                    if (data)
                        return `
                                    <div class="dropdown text-center">
                                  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                                    Actions
                                  </button>
                                  <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
             
                                                    <li><a class="dropdown-item"  href="/Contacts/Edit/${clientId}/${data}">Edit</a></li>
           
                                  </ul>
                                </div>
                           `;
                    else
                        return ``;
                },

            },
        ]
    })
    //return table;
}