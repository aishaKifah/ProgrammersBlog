

$(document).ready(function () {
    const dataTable = $('#UsersTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Add',
                attr: { id: "btnAdd" },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {

                }
            }
            ,
            {
                text: 'refresh', // no infor,ation about user will be dleted in the toastr 
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/User/GetAllUsers/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#usersTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const userListDto = jQuery.parseJSON(data);
                            dataTable.clear();

                            console.log(userListDto);
                            console.log(userListDto.ResultStatus);

                            if (userListDto.ResultStatus === 0) {
                                $.each(userListDto.Users.$values,
                                    function (index, user) {
                                        const newAddedtableRow=dataTable.row.add([
                                            user.Id,
                                            user.UserName,
                                            user.Email,
                                            user.PhoneNumber,
                                            `<img src="/img/${user.picture}" alt="${user.UserName}" class="my-image-table" />`,

                                            `<td>
                                                <button class="btn btn-primary btn-sm btn-update" data-id="${user.Id}" > <span class="fas fa-edit"></span></button>
                                                <button class="btn btn-danger btn-delete btn-sm" data-id="${user.Id}"> <span class="fas fa-minus-circule"></span></button>
                                            </td>`


                                        ]).node();
                                        const jqueryTableRow = $(newAddedtableRow);
                                         jqueryTableRow.attr('name', `${user.Id}`);


                                    });
                                dataTable.draw();

                                $('.spinner-border').hide(1400);
                                $('#UsersTable').fadeIn();

                            } else {
                                toastr.error(`${userListDto.Massege}`, 'error');


                            }

                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#usersTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'error');

                        }


                    });
                }
            }
        ]





    });
    /* Datatable ends here */
    /* Ajax GET / Getting the _UserAddpartial view as Model Form strats here*/
    const palceHolderDiv = $('#userPlaceHolder'); /* get userPlaceHolder, $ means jquery */

    $(function () {
        const url = "/Admin/User/Add/";


        $('#btnAdd').click(function () {

            $.get(url).done(function (data) {
                /* Ajex get islemi */
                console.log('from show partial ');

                palceHolderDiv.html(data);

                palceHolderDiv.find(".modal").modal('show');


            });


        });
        palceHolderDiv.on('click',
            '#btnSave_', function (event) {// 1- ما عم يشوف الزر
                console.log("oldu kuveyet");
                event.preventDefault();
                const form = $('#form-user-add');
                const actionUrl = form.attr('action');
                const dataToSend = new FormData(form.get(0));// 0'inici index'teki formun bilgilerini buruya aktar
                $.ajax({// jQuery post  kullaniyorduk, smidi jQuery ajaxj
                    url: actionUrl,
                    type: 'POST',
                    data: dataToSend,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        const userAddAjaxModel = jQuery.parseJSON(data);
                        const newFormBody = $('.modal-body', userAddAjaxModel.UserAddPartial);
                        console.log(userAddAjaxModel);
                        palceHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = $("input[name=IsValid]").val() === "True";

                        if (isValid) {

                            console.log(userAddAjaxModel.UserDto.User);
                            palceHolderDiv.find('.modal').modal('hide');
                            const newAddedtableRow=dataTable.row.add([
                                userAddAjaxModel.UserDto.User.Id,
                                userAddAjaxModel.UserDto.User.UserName,
                                userAddAjaxModel.UserDto.User.Email,
                                userAddAjaxModel.UserDto.User.PhoneNumber,
                                `<td><img src="/img/${userAddAjaxModel.UserDto.User.picture}" alt="${userAddAjaxModel.UserDto.User.UserName}" style="max-height:50px; max-width:50px;" /</td>`,

                                `

                                <td>
                                    <button class="btn btn-primary btn-sm btn-update" data-id="${userAddAjaxModel.UserDto.User.Id}" > <span class="fas fa-edit"></span> </button>
                                    <button class="btn btn-danger btn-delete btn-sm" data-id="${userAddAjaxModel.UserDto.User.Id}" > <span class="fas fa-minus-circule"> </span></button>
                                </td>`


                            ]).node();
                            const jqueryTableRow = $(newAddedtableRow);
                            jqueryTableRow.attr('name', `${userAddAjaxModel.UserDto.User.Id}`);
                            dataTable.draw(newAddedtableRow);
                            if ($('.btn-update').length) {
                                console.log($('.btn-update').html);
                            }
                            
                            toastr.success(`${userAddAjaxModel.UserDto.Massege}`, 'Sucsses');
                        } else {
                            let summaryText = "";
                            $('#validation-summary > ul > li').each(function () {
                                let text = $(this).text();
                                summaryText = `*${text}\n`;
                            });
                            toastr.warning(summaryText);
                        }
                    },
                    error: function (err) {
                        console.log(err);
                        toastr.error(`${err.responseText}`, "Error!")



                    }
                });
            });
    })

        /* Ajax GET / Getting the _UserAddpartial as Model Form ends here */


    /* Ajax POST ? posting the formatData as UserAddDto ends here */
        /* Ajax Post / Postting the FormData userAddto Starts here */

       /* 8/



        /* Ajax POST ? posting the formatData as UserAddDto ends here */


        /* Ajax GET / Getting the _UserUpdatepartial view as Model Form strats here*/
   
       

    $(document).on('click',// optimistic concurrency failure object has been modified, error occord when try to update users frequently 
        '.btn-update', function (event) {
            event.preventDefault();

                console.log("basildi");

                const url = "/Admin/User/Update/";


                const id = $(this).attr('data-id');

                $.get(url, { userId: id }).done(function (data) {
                    /* Ajex get islemi */

                    palceHolderDiv.html(data);

                    palceHolderDiv.find(".modal").modal('show');


                }).fail(function () {
                    toaster.error("Erorr!")
                });
                /* Ajax POST / updating user starts here*/
                palceHolderDiv.on('click',
                    '#btnUpdate',

                    function (event) {
                        event.preventDefault();
                        const form = $('#form-user-update'); //formu seciyoruz
                        const actionUrl = form.attr('action');
                        const dataToSend = new FormData(form.get(0));

                        $.ajax({// jQuery post  kullaniyorduk, smidi jQuery ajaxj , upload islemi gerceklesebilecegimiz icin ajax kullandik
                            url: actionUrl,
                            type: 'POST',
                            data: dataToSend,
                            processData: false,
                            contentType: false,
                            success: function (data) {//

                                const userUpdateAjaxModel = jQuery.parseJSON(data);
                                console.log(userUpdateAjaxModel);
                                
                                const newFormBody = $('.modal-body', userUpdateAjaxModel.UserUpdatePartial);
                                palceHolderDiv.find('.modal-body').replaceWith(newFormBody);
                                const isValid  = $("input[name=IsValid]").val() === "True";//$("input[name=IsValid]").val() === "True";
                                console.log('usvalid' + isValid);
                                if (isValid) { // ما عم يصير صح 
                                    const id = userUpdateAjaxModel.UserDto.User.Id;
                                    console.log('after sucsess');// 2- ما عم يروح للصفحة الرئيسية 

                                    const tableRow = $(`[name="${id}"]`);
                                    palceHolderDiv.find('.modal').modal('hide');
                                    dataTable.row(tableRow).data([
                                        userUpdateAjaxModel.UserDto.User.Id,
                                        userUpdateAjaxModel.UserDto.User.UserName,
                                        userUpdateAjaxModel.UserDto.User.Email,
                                        userUpdateAjaxModel.UserDto.User.PhoneNumber,
                                        `<td><img src="/img/${userUpdateAjaxModel.UserDto.User.picture}" alt="${userUpdateAjaxModel.UserDto.User.UserName}" class="my-image-table" /</td>`,

                                        `
  
                                  <td>
                                      <button class="btn btn-primary btn-sm btn-update" data-id="${userUpdateAjaxModel.UserDto.User.Id}" ><span class="fas fa-edit"></span></button>
                                      <button class="btn btn-danger btn-delete btn-sm" data-id="${userUpdateAjaxModel.UserDto.User.Id}"><span class="fas fa-minus-circule"></span></button>
                                  </td>`


                                    ]);
                                    console.log("from save button");
                                    tableRow.attr("name", `${id}`); // row'un name ozelligini de duzeltiyoruz
                                    dataTable.row(tableRow).invalidate();// secttigimiz indexteki row'un datasini duzeltiyor
                                    toastr.success(`${userUpdateAjaxModel.UserDto.Massege}`, 'Sucsses');

                                } else {
                                    let summaryText = "";
                                    $('#validation-summary > ul > li').each(function () {
                                        let text = $(this).text();
                                        summaryText = `*${text}\n`;
                                    });
                                    toastr.warning(summaryText);
                                }
                            },
                            error: function (error) {
                                console.log(err);

                                toastr.error(`${err.responseText}`, "Error!")

                            }
                        });

                    })


            });
        

        /* Ajax GET / Getting the _UserUpdatepartial as Model Form ends here */
      
        /* Ajax POST ? Deleting a user  starts  here */
        $(document).on('click',
            '.btn-delete',
            function (event) {

                const id = $(this).attr('data-id');
                event.preventDefault();
                const tableRow = $(`[name="${id}"]`);
                const userName = tableRow.find('td:eq(1)').text();

                Swal.fire({
                    title: 'Are you sure?',
                    text: `${userName} will be deleted`,
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes, delete it!'
                }).then((result) => {
                    if (result.isConfirmed) {
                        console.log("confirmed " + userName + "id: " + id);

                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            data: { userId: id },
                            url: '/Admin/User/Delete/',
                            success: function (data) {
                                console.log(data);
                                const userDto = jQuery.parseJSON(data);
                                console.log(userDto);

                                if (userDto.ResultStatus === 0) {
                                    Swal.fire(
                                        'Deleted!',
                                        `${userDto.User.userName} has been deleted `,
                                        'success'
                                    );
                                    const tableRow = $(`[name="${id}"]`);
                                    dataTable.row.remove(tableRow).draw();
                                } else {
                                    Console.log("not confirmed ", userName);

                                    Swal.fire({

                                        icon: 'error',
                                        title: 'Oops...',
                                        text: userDto.Massege,
                                    });
                                }


                            },
                            error: function (err) {
                                console.log(err);
                                toastr.error(`${err.responseText}`, "Error!")
                            }
                        })

                    }
                });

            });



      
    });