$(function () {
    var l = abp.localization.getResource('ITCOURSES');
    var createModal = new abp.ModalManager(abp.appPath + 'CourseOpeningSchedules/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'CourseOpeningSchedules/EditModal');



    var dataTable = $("#CourseOpeningSchedulesTable").DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(iTCOURSES.courses.courseOpeningSchedule.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('ITCOURSES.CourseOpeningSchedules.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('ITCOURSES.CourseOpeningSchedules.Delete'), //CHECK for the PERMISSION
                                    confirmMessage: function (data) {
                                        return l('BookDeletionConfirmationMessage', data.record.nameCourseOpeningSchedule);
                                    },
                                    action: function (data) {
                                        iTCOURSES.courses.courseOpeningSchedule
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('NameCourseOpeningSchedule'),
                    data: "nameCourseOpeningSchedule"
                },
                {
                    title: l('DateOpening'),
                    data: "dateOpening",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: l('TimeStart'),
                    data: "timeStart"
                  
                }   
            ]
        })
    );
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $("#NewCourseOpeningSchedulesButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    $('#PrintAuthorButton').click(function (e) {
        e.preventDefault();
        //getTableInstance().print();
        var HTML = $("html");
        var cln = document.documentElement.innerHTML;
        document.documentElement.innerHTML = cln;
        HTML.html($("#CourseOpeningSchedulesTable"));
        window.print();
        document.documentElement.innerHTML = cln;
    });
});

