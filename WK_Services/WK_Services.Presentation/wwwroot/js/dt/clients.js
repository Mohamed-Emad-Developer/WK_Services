function clientsTable(url) {

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
            datatype: "json"

        },
        columns: [
            { data: "name", title: 'Name' },
            { data: "phone", title: 'Phone' },
            { data: "email", title: 'Email Address' },
            { data: "country", title: 'Country' },
            { data: "city", title: 'City' },
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
                                                    <li><a class="dropdown-item"  href="/Contacts/Index/${data}">Add Contact</a></li>
                                                    <li><a class="dropdown-item"  href="/Clients/Edit/${data}">Edit</a></li>
           
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