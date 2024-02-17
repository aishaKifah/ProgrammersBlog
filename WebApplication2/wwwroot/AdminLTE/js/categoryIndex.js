$(document).ready(function () {
    $('#categoriesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "order": [[6, 'desc']],

        buttons: [
            {
                text: 'Add',
                attr: { id: "btnAdd" },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {

                }
            },
            {
                text: 'refresh',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Category/GetAllCategories/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#categoriesTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const categoryListDto = jQuery.parseJSON(data);
                         

                            if (categoryListDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(categoryListDto.CategoryListDto_.$values,
                                    function (index, category) {
                                        console.log(category);
                                        tableBody += `
                                              <tr name=${category.id}>
                                                <td>${category.id}</td>
                                                <td>${category.Name}</td>
                                                <td>${category.Description}</td>
                                                <td>${category.isActive? "Yes":"No"}</td>
                                                <td>${category.isDeleted ? "Yes" : "No"}</td>
                                                <td>${category.note}</td>
                                                <td>${convertToshortDate(category.createdDate)}</td>
                                                <td>${category.createdByname}</td>
                                                <td>${convertToshortDate(category.modifiedDate)}</td>
                                                <td>${category.modifiedByName}</td>
                                                <td>
                                                <button class="btn btn-primary btn-sm btn-update " data-id="${category.id}" ><span class="fas fa-edit"></span></button>
                                                <button class="btn btn-danger btn-sm btn-delete " data-id="${category.id}"><span class="fas fa-minus-circule"></span></button>
                                                </td>

                                                        </tr>`;



                                    });

                                $('#categoriesTable > tbody').replaceWith(tableBody);
                                $('.spinner-border').hide();
                                $('#categoriesTable').fadeIn(1400);

                            } else {
                                toastr.error(`${categoryListDto.Massege}`, 'error');


                            }

                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#categoriesTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'error');

                        }


                    });
                }
            }
        ]





    });
    /* Datatable ends here */
    /* Ajax GET / Getting the _categorAdpartial view as Model Form strats here*/

    $(function () {
        const url = "/Admin/Category/Add/";

        const palceHolderDiv = $('#categoryPlaceHolder'); /* get categoryPlaceHolder, $ means jquery */

        $('#btnAdd').click(function () {

            $.get(url).done(function (data) {
                /* Ajex get islemi */

                palceHolderDiv.html(data);

                palceHolderDiv.find(".modal").modal('show');


            });


        });

        /* Ajax GET / Getting the _CategoryAddPArtial as Model Form ends here */
        /* Ajax Post / Postting the FormData CategoryAddto Starts here */

        palceHolderDiv.on('click',
            '#btnSave',
            function (event) {
                console.log("from catogary ")
                event.preventDefault(); /* btn'nin kendi click islemini engler' */
                            const form = $('#form-category-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();

                $.post(actionUrl, dataToSend).done(function (data) {
                    const categoryAddAjaxModel = jQuery.parseJSON(data);
                    const newFormBody = $('.modal-body', categoryAddAjaxModel.categoryAddPartial);

                    palceHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = $("input[name=IsValid]").val() === "True";

                    if (isValid) {

                        palceHolderDiv.find('.modal').modal('hide');
                        console.log(categoryAddAjaxModel.categoryDto.CategoryDto_);
                        const newTableRow = ` <tr name="${categoryAddAjaxModel.categoryDto.CategoryDto_.id}">
                                <td>${categoryAddAjaxModel.categoryDto.CategoryDto_.id}</td>
                                <td>${categoryAddAjaxModel.categoryDto.CategoryDto_.Name}</td>
                                <td>${categoryAddAjaxModel.categoryDto.CategoryDto_.Description}</td>
                                <td>${(categoryAddAjaxModel.categoryDto.CategoryDto_.isActive.toString())}</td>
                                <td>${convertFirstLetterToUpperCase(categoryAddAjaxModel.categoryDto.CategoryDto_.isDeleted.toString())}</td>
                                <td>${categoryAddAjaxModel.categoryDto.CategoryDto_.note}</td>
                                <td>${convertToshortDate(categoryAddAjaxModel.categoryDto.CategoryDto_.createdDate)}</td>
                                <td>${categoryAddAjaxModel.categoryDto.CategoryDto_.createdByname}</td>
                                <td>${convertToshortDate(categoryAddAjaxModel.categoryDto.CategoryDto_.modifiedDate)}</td>
                                <td>${categoryAddAjaxModel.categoryDto.CategoryDto_.modifiedByName}</td>
                                <td>
                                                <button class="btn btn-primary btn-sm btn-update data-id="${categoryUpdateAjaxModel.categoryDto.CategoryDto_.id}" ><span class="fas fa-edit"></span></button>
                                                <button class="btn btn-danger btn-sm btn-delete" data-id="${categoryAddAjaxModel.categoryDto.CategoryDto_.id}"><span class="fas fa-minus-circule"></span></button>
                                 </td>

                            </tr>`;
                        const newTableRowObject = $(newTableRow);
                        newTableRowObject.hide();
                        $('#categoriesTable').append(newTableRowObject);
                        newTableRowObject.fadeIn(3500);
                        toastr.success(`${categoryAddAjaxModel.categoryDto.Massege}`, 'Sucsses');
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });
    });

    /* Ajax POST ? posting the formatData as CategoryAddDto ends here */

    /* Ajax POST ? Deleting a category starts  here */
    $(document).on('click',
        '.btn-delete',
        function (event) {

            const id = $(this).attr('data-id');
            event.preventDefault();
            const tableRow = $(`[name="${id}"]`);
            const categoryName = tableRow.find('td:eq(1)').text();
            console.log(categoryName);

            Swal.fire({
                title: 'Are you sure?',
                text: `${categoryName} will be deleted`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { categoryToDelete: id },
                        url: '/Admin/Category/Delete/',
                        success: function (data) {
                            console.log(data);
                            const result = jQuery.parseJSON(data);
                            if (result.ResultStatus === 0) {
                                Swal.fire(
                                    'Deleted!',
                                    result.Massege,
                                    'success'
                                );
                                const tableRow = $(`[name="${id}"]`);
                                tableRow.fadeOut(3500);
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Oops...',
                                    text: result.Massege,
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
    $(function () {

        const url = '/Admin/Category/Update/';
        const placeHolderDiv = $('#categoryPlaceHolder');
        $(document).on('click',
            '.btn-update', function (event) {
            console.log("clicked");
            event.preventDefault();
            const id = $(this).attr('data-id');
            $.get(url, { categoryId: id }).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find('.modal').modal('show');
            }).fail(function () {
                toastr.error("Error");
            });
        });


        /* Ajax POST / updating starts here*/
        placeHolderDiv.on('click', '#btnUpdate', function () {
            event.preventDefault();
            const form = $('#form-category-update'); //formu seciyoruz
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();// categoryUpdatDto hali ile gonderme
            console.log(actionUrl+" data : "+ dataToSend)
            $.post(actionUrl, dataToSend).done(function (data) {
                const categoryUpdateAjaxModel = jQuery.parseJSON(data);
                console.log('categoryUpdateAjaxModel\n'+categoryUpdateAjaxModel);
                const newFormBody = $('.modal-body', categoryUpdateAjaxModel.categoryUpdatePartial)
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = $("input[name=IsValid]").val() === "True";
                if (isValid) {
                    placeHolderDiv.find('.modal').modal('hide');
                    console.log(categoryUpdateAjaxModel);
                    const newTableRow = ` <tr name="${categoryUpdateAjaxModel.categoryDto.CategoryDto_.id}">
                                <td>${categoryUpdateAjaxModel.categoryDto.CategoryDto_.id}</td>
                                <td>${categoryUpdateAjaxModel.categoryDto.CategoryDto_.Name}</td>
                                <td>${categoryUpdateAjaxModel.categoryDto.CategoryDto_.Description}</td>
                                <td>${(categoryUpdateAjaxModel.categoryDto.CategoryDto_.isActive.toString())}</td>
                                <td>${convertFirstLetterToUpperCase(categoryUpdateAjaxModel.categoryDto.CategoryDto_.isDeleted.toString())}</td>
                                <td>${categoryUpdateAjaxModel.categoryDto.CategoryDto_.note}</td>
                                <td>${convertToshortDate(categoryUpdateAjaxModel.categoryDto.CategoryDto_.createdDate)}</td>
                                <td>${categoryUpdateAjaxModel.categoryDto.CategoryDto_.createdByname}</td>
                                <td>${convertToshortDate(categoryUpdateAjaxModel.categoryDto.CategoryDto_.modifiedDate)}</td>
                                <td>${categoryUpdateAjaxModel.categoryDto.CategoryDto_.modifiedByName}</td>
                                <td>
                                                <button class="btn btn-primary btn-sm byn-update data-id="${categoryUpdateAjaxModel.categoryDto.CategoryDto_.id}" ><span class="fas fa-edit"></span></button>
                                                <button class="btn btn-danger btn-sm btn-delete" data-id="${categoryUpdateAjaxModel.categoryDto.CategoryDto_.id}"><span class="fas fa-minus-circule"></span></button>
                                 </td>

                            </tr>`;
                    const newTableRowObject = $(newTableRow);
                    const categoryTableRow = $(`[name="${categoryUpdateAjaxModel.categoryDto.CategoryDto_.id}"]`);
                    newTableRowObject.hide();
                    categoryTableRow.replaceWith(newTableRowObject);
                    newTableRowObject.fadeIn(3500);
                    toastr.success(`${categoryUpdateAjaxModel.categoryDto.Massege}"`, " Succsess..")

                } else {
                    let summaryText = "";
                    $('#validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summaryText = `*${text}\n`;
                    });
                    toastr.warning(summaryText);
                }
            }).fail(function (response) {
                console.log(response);

            })

        })
    });
});