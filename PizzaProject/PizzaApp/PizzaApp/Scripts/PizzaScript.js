function getPrice(pizzaId) {
    var size = document.getElementById(`size_${pizzaId}`).value;
    $.get(`https://localhost:44326/GetPrice/getprice?id=${pizzaId}&size=${size}`,
        function (data) {
            document.getElementById(`price_${pizzaId}`).innerText = data;

        });
}

//function addOrderToDB(pizzaId) {
//    var price = document.getElementById(`price_${pizzaId}`).textContent;
//    var sizeEl = document.getElementById(`size_${pizzaId}`);
//    var size = sizeEl.options[sizeEl.selectedIndex].text;

//    $.get(`https://localhost:44326/GetPrice/addordertodb?pizzaId=${pizzaId}&price=${price}&size=${size}`,
//        function (data) {
//            document.getElementById(`check_${pizzaId}`).innerText = data;
//        });
//}

//function addOrderToDB(pizzaId, userName) {
//    var price = document.getElementById(`price_${pizzaId}`).textContent;
//    var sizeEl = document.getElementById(`size_${pizzaId}`);
//    var size = sizeEl.options[sizeEl.selectedIndex].text;

//    $.get(`https://localhost:44326/GetPrice/addordertodb?pizzaId=${pizzaId}&price=${price}&size=${size}&userName=${userName}`,
//        function (data) {
//            document.getElementById(`check_${pizzaId}`).innerText = data;
//        });
//}


function addOrderToDB(pizzaId, userName) {
    var sizeEl = document.getElementById(`size_${pizzaId}`);
    var size = sizeEl.options[sizeEl.selectedIndex].value;

    $.get(`https://localhost:44326/GetPrice/addordertodb?pizzaId=${pizzaId}&size=${size}&userName=${userName}`,
        function (data) {
            document.getElementById(`check_${pizzaId}`).innerText = data;
        });
}




//Function is valiable. Use to change data without refresh page

//function deleteOrder(orderId) {
//    $.get(`https://localhost:44326/GetPrice/deleteorder?orderId=${orderId}`,
//        function (data) {
//            alert(data);
//        });
//}




function CountPrice() {

    var checkedBoxes = document.querySelectorAll('input[type=checkbox]:checked');

    //alert(checkedBoxes.length);

    var arrId = [];
    var arrToQuery=null;
    
    checkedBoxes.forEach(function addIdIngredients(item, index) {
        var ingredientId = item.id;
        arrId.push(ingredientId);
 
    });

    arrId.forEach(function convertToQuery(item, index) {
        if (index==0) {
            arrToQuery = `arrId=${arrId[0]}`;
        }
        
        if (index>0) {
            arrToQuery += `&arrId=${arrId[index]}`;
        }
        
    });

    var size = "small";
    var radioSize = document.querySelector('input[type=radio]:checked');
    if (radioSize !=null) {
        size = radioSize.value;
    }
   // alert(arrId.toString());
  // alert(arrToQuery);
   
       $.get(`https://localhost:44326/GetPrice/countprice?${arrToQuery}&size=${size}`,
        function (data) {
            document.getElementById("CurrentPrice").innerText = data;
            document.getElementById("FinalPrice").value = data;
        });
}




function AddCreatedPizzaToOrder(id) {
    //var id = document.getElementById("id_order").textContent;
    var id = id;
    //var idPizza = document.getElementById("id_pizza").textContent;
    //var idPizza = idPizza;
    //var image = image;
    var name = document.getElementById("name").textContent;
    var size = document.getElementById("size").textContent;
    var price = document.getElementById("price").textContent;
    alert(id);
    $.post(`https://localhost:44326/GetPrice/addcreatedpizzatoorder`,
        { Id: id, Name: name, Size: size, Price: price }).
        done(function (data) {
            alert(data);
        });

}