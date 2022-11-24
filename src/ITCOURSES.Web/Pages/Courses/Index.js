$(function () {
    var l = abp.localization.getResource('ITCOURSES');
    var createModal = new abp.ModalManager(abp.appPath + 'Courses/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Courses/EditModal');



    var dataTable = $('#CoursesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(iTCOURSES.courses.course.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('ITCOURSES.Courses.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },  
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('ITCOURSES.Courses.Delete'),
                                    confirmMessage: function (data) {
                                        return l('BookDeletionConfirmationMessage', data.record.courseName);
                                    },
                                    action: function (data) {
                                        iTCOURSES.courses.course
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
                    title: l('Name'),
                    data: "courseName"
                },
                {
                    title: l('NameClass'),
                    data: "className"
                },
                {
                    title: l('Schedule'),
                    data: "schedule"
                    
                },
                {
                    title: l('Fee'),
                    data: "fee",
                },
                {
                    title: l('Description'),
                    data: "description"
                },
                {
                    title: l('CourseOpeningSchedule'),
                    data: "nameCourseOpeningSchedule"
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
    $('#NewCourseButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    $('#PrintAuthorButton').click(function (e) {
        e.preventDefault();
        //getTableInstance().print();
        var HTML = $("html");
        var cln = document.documentElement.innerHTML;
        document.documentElement.innerHTML = cln;
        HTML.html($('#CoursesTable'));
        window.print();
        document.documentElement.innerHTML = cln;
    });
});
