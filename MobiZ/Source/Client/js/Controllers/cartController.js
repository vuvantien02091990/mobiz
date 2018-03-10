var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $("#btnContinue").off('click').on('click', function () {
            window.location.href = "/";
        });
        $("#btnUpdate").off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Product: {
                        ID: $(item).data('id')
                    },
                    Quantity: $(item).val()
                });
            });
            $.ajax({
                url: '/CartItem/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true)
                    {
                        window.location.href = "/gio-hang"
                    }

                }

            })
        });
        $(".btn-delete").off('click').on('click', function () {
            $.ajax({
                url: '/CartItem/Delete',
                data: { id:$(this).data('id')},
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang"
                    }

                }

            })
        });
        $("#btnDeleteAll").off('click').on('click', function () {
            $.ajax({
                url: '/CartItem/DeleteAll',
                
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang"
                    }

                }

            })
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
    }
};
cart.init();
