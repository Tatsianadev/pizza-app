function getPrice(pizzaId) {
    var size = document.getElementById(`size_${pizzaId}`).value;
    $.get(`https://localhost:44326/GetPrice/getprice?id=${pizzaId}&size=${size}`,
        function (data) {
            document.getElementById(`price_${pizzaId}`).innerText = data;

        });
}

function addOrderToDB(pizzaId) {
    var price = document.getElementById(`price_${pizzaId}`).textContent;
    var sizeEl = document.getElementById(`size_${pizzaId}`);
    var size = sizeEl.options[sizeEl.selectedIndex].text;

    $.get(`https://localhost:44326/GetPrice/addordertodb?pizzaId=${pizzaId}&price=${price}&size=${size}`,
        function (data) {
            document.getElementById(`check_${pizzaId}`).innerText = data;
        });
}

function deleteOrder(orderId) {
    $.get(`https://localhost:44326/GetPrice/deleteorder?orderId=${orderId}`,
        function (data) {
            alert(data);
        });
}




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





//function GetPriceBySize() {
    
//    var radios = document.querySelectorAll('input[Name="radio"]');
//    for (var i = 0, max = radios.length; i < max; i++) {
//        radios[i].addEventListener("click",
//            function () {
//                var size = this.value;
//                var basePrice = document.getElementById("CurrentPrice").textContent;
//                var sizeBefore = document.getElementById("sizeBefore").textContent;
//                $.get(`https://localhost:44326/GetPrice/countpricebysize?size=${size}&sizeBefore=${sizeBefore}&price=${basePrice}`,
//                    function (data) {
//                        var originalData = data;
//                        var price = originalData.slice(1, originalData.length - 4);
//                        alert(price);
//                        var sizeBefore = data[data.length - 2];
//                        alert(sizeBefore);
//                        document.getElementById("CurrentPrice").innerText = price;
//                        document.getElementById("sizeBefore").innerText = sizeBefore;
//                    });
//            });

//    }
//}

function GetPriceBySize() {
    var size = this.value;
    var basePrice = document.getElementById("CurrentPrice").textContent;
    var sizeBefore = document.getElementById("sizeBefore").textContent;
    $.get(`https://localhost:44326/GetPrice/countpricebysize?size=${size}&sizeBefore=${sizeBefore}&price=${basePrice}`,
        function (data) {
            var originalData = data;
            var price = originalData.slice(1, originalData.length - 4);
            alert(price);
            var sizeBefore = data[data.length - 2];
            alert(sizeBefore);
            document.getElementById("CurrentPrice").innerText = price;
            document.getElementById("sizeBefore").innerText = sizeBefore;
        });
}
