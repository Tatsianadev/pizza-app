function getPrice(pizzaId) {
    var size = document.getElementById(`size_${pizzaId}`).value;
    $.get(`https://localhost:44326/GetPrice/getprice?id=${pizzaId}&size=${size}`,
        function (data) {
            document.getElementById(`price_${pizzaId}`).innerText = data;
        });
}

function addOrderToDB(pizzaId) {
    var price = document.getElementById(`price_${pizzaId}`).textContent;
    $.get(`https://localhost:44326/GetPrice/addordertodb?pizzaId=${pizzaId}&price=${price}`,
        function(data) {
            document.getElementById(`check_${pizzaId}`).innerText = data;
        });
}

function deleteOrder(orderId) {
    $.get(`https://localhost:44326/GetPrice/deleteorder?orderId=${orderId}`,
        function(data) {
            alert(data);
        });
}