let ordersTable;
function allOrdersTable(url) {

    ordersTable = $('#my_dt').DataTable({
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
            { data: "orderNumber", title: 'Order Number' },
            { data: "clientName", title: 'Client Name' },
            { data: "orderType", title: 'Order Type' },
            { data: "serviceName", title: 'Service' },
            { data: "quantity", title: 'Quantity' },
            { data: "deliveryDate", title: 'Requested Delivery Date' },
           
        ]
    })
   
}
function clientOrdersTable(url) {

    ordersTable = $('#my_dt').DataTable({
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
            { data: "orderNumber", title: 'Order Number' },
            { data: "orderType", title: 'Order Type' },
            { data: "serviceName", title: 'Service' },
            { data: "quantity", title: 'Quantity' },
            { data: "deliveryDate", title: 'Requested Delivery Date' },

        ]
    })

}