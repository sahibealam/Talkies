<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateMasterAdmin.master" AutoEventWireup="true"
    CodeFile="AlbumSearch.aspx.cs" Inherits="AlbumSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="main-content">
        <div class="main-content-inner">
            <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"
                EnablePageMethods="true" AsyncPostBackTimeout="6000">
            </cc1:ToolkitScriptManager>
            <asp:UpdatePanel ID="up" runat="server">
                <ContentTemplate>
                    <div class="page-content">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <asp:Label ID="lblBank" runat="server" Text="Album Name*" CssClass="control-label no-padding-right"></asp:Label>
                                            <asp:TextBox ID="txtAlbumName" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label4" runat="server" Text="Genere*" CssClass="control-label no-padding-right"></asp:Label>

                                        <asp:ListBox ID="lbGenere" runat="server" SelectionMode="Multiple" class="chosen-select form-control"
                                            data-placeholder="Choose a Genere..."></asp:ListBox>

                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label9" runat="server" Text="Studio*" CssClass="control-label no-padding-right"></asp:Label>
                                        <asp:DropDownList ID="ddlStudio" runat="server" CssClass="form-control" AutoPostBack="true">
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label10" runat="server" Text="Director*" CssClass="control-label no-padding-right"></asp:Label>
                                        <asp:ListBox ID="lbDirector" runat="server" SelectionMode="Multiple" class="chosen-select form-control"
                                            data-placeholder="Choose a Director..."></asp:ListBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label11" runat="server" Text="SupportingActor*" CssClass="control-label no-padding-right"></asp:Label>
                                        <asp:ListBox ID="lbSupportingActor" runat="server" SelectionMode="Multiple" class="chosen-select form-control"
                                            data-placeholder="Choose a SupportingActor..."></asp:ListBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="Starring*" CssClass="control-label no-padding-right"></asp:Label>
                                        <asp:ListBox ID="lbStarring" runat="server" SelectionMode="Multiple" class="chosen-select form-control"
                                            data-placeholder="Choose a Starring..."></asp:ListBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label113" runat="server" Text="Category*" CssClass="control-label no-padding-right"></asp:Label>
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <asp:Button ID="btnSearch" Text="Search" OnClick="btnSearch_Click" runat="server"
                                        CssClass="btn btn-success"></asp:Button>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-12">
                                    <div style="overflow: auto">
                                        <asp:GridView ID="grdPost" runat="server" CssClass="table table-striped table-bordered table-hover"
                                            AutoGenerateColumns="False" EmptyDataText="No Records Found" OnRowDataBound="grdPost_RowDataBound"
                                            OnPreRender="grdPost_PreRender">
                                            <Columns>
                                                <asp:BoundField DataField="Album_Id" HeaderText="Album_Id">
                                                    <HeaderStyle CssClass="displayStyle" />
                                                    <ItemStyle CssClass="displayStyle" />
                                                    <FooterStyle CssClass="displayStyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Album_Rating" HeaderText="Album_Rating">
                                                    <HeaderStyle CssClass="displayStyle" />
                                                    <ItemStyle CssClass="displayStyle" />
                                                    <FooterStyle CssClass="displayStyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="List_Director" HeaderText="List_Director">
                                                    <HeaderStyle CssClass="displayStyle" />
                                                    <ItemStyle CssClass="displayStyle" />
                                                    <FooterStyle CssClass="displayStyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="List_Actor" HeaderText="List_Actor">
                                                    <HeaderStyle CssClass="displayStyle" />
                                                    <ItemStyle CssClass="displayStyle" />
                                                    <FooterStyle CssClass="displayStyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="List_Supporting" HeaderText="List_Supporting">
                                                    <HeaderStyle CssClass="displayStyle" />
                                                    <ItemStyle CssClass="displayStyle" />
                                                    <FooterStyle CssClass="displayStyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="List_Genere" HeaderText="List_Genere">
                                                    <HeaderStyle CssClass="displayStyle" />
                                                    <ItemStyle CssClass="displayStyle" />
                                                    <FooterStyle CssClass="displayStyle" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="S No.">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Album_Name" HeaderText="Album" />
                                                <asp:BoundField DataField="Album_Description" HeaderText="Description" />

                                                <asp:TemplateField HeaderText="Rating">
                                                    <ItemTemplate>
                                                        <cc1:Rating ID="Rating1" runat="server" Direction="LeftToRight" MaxRating="5" RatingDirection="LeftToRightTopToBottom"
                                                            RatingAlign="Horizontal" CurrentRating='0' StarCssClass="ratingStar"
                                                            WaitingStarCssClass="savedRatingStar"
                                                            FilledStarCssClass="filledRatingStar"
                                                            EmptyStarCssClass="emptyRatingStar" Width="80px">
                                                        </cc1:Rating>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:BoundField DataField="Album_Mounting_Rating" HeaderText="Mounting Rating" />
                                                <asp:BoundField DataField="Category_Name" HeaderText="Category" />

                                                <asp:TemplateField HeaderText="Genere">
                                                    <ItemTemplate>
                                                        <asp:BulletedList ID="List_Genere_id" runat="server"></asp:BulletedList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Star">
                                                    <ItemTemplate>
                                                        <asp:BulletedList ID="List_Star_id" runat="server"></asp:BulletedList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Supporting">
                                                    <ItemTemplate>
                                                        <asp:BulletedList ID="List_Suppoprting_id" runat="server"></asp:BulletedList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Director">
                                                    <ItemTemplate>
                                                        <asp:BulletedList ID="List_Director_id" runat="server"></asp:BulletedList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:BoundField DataField="Album_AddedOn" HeaderText="Created  On" />
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" runat="server" Width="25px" Height="25px" ImageUrl="~/assets/images/delete.png"
                                                            OnClick="btnDelete_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Review">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnReview" runat="server" Width="30px" Height="25px" ImageUrl="~/assets/images/go.png"
                                                            OnClick="btnReview_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" runat="server" Width="25px" Height="25px" ImageUrl="~/assets/images/edit.png"
                                                            OnClick="btnEdit_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Slide Show">
                                                    <ItemTemplate>
                                                        <a data-toggle="modal" data-target="#LiteboxModel" onclick="fillBody(this);">View</a>
                                                        <asp:HiddenField ID="hf_albumPreview" runat="server" Value="0" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                            <FooterStyle BackColor="blue" ForeColor="White" Font-Bold="true" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:HiddenField ID="hf_Album_Id" runat="server" Value="0" />

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


    <div class="modal fade" id="LiteboxModel" tabindex="-1" role="dialog" aria-labelledby="LoginLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">

                    <h5 class="modal-title" id="LoginLabel"><b>Preview</b></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                
                <div class="modal-body" id="previewBody">
                    <asp:DataList ID="DataList1" Visible="true" runat="server" AutoGenerateColumns="false"
                    RepeatColumns="2" CellSpacing="5">
                    <ItemTemplate>
                        <u>
                            <%# Eval("Name") %></u>
                        <hr />
                        <video id="VideoPlayer" src='<%# Eval("Id", "File.ashx?Id={0}") %>' controls="true"
                            width="300" height="300" loop="true" />
                    </ItemTemplate>
                </asp:DataList>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
               
            </div>
        </div>
    </div>




    <link rel="stylesheet" href="assets/css/myStyle.css" type="text/css" media="screen" />
    <script type="text/javascript" language="javascript" src="assets/js/lytebox.js"></script>
    <link rel="stylesheet" href="assets/css/lytebox.css" type="text/css" media="screen" />
    <!-- DataTable specific plugin scripts -->
    <%--<link rel="stylesheet" href="assets/css/lytebox.css" type="text/css" media="screen" />--%>
    <script src="assets/js/jquery-2.1.4.min.js"></script>
    <%--<script src="assets/js/lytebox.js"></script>--%>
    <script src="assets/js/model.js"></script>
    <%--<script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery.dataTables.min.js"></script>
    <script src="assets/js/jquery.dataTables.bootstrap.min.js"></script>
    <script src="assets/js/dataTables.buttons.min.js"></script>
    <script src="assets/js/buttons.flash.min.js"></script>
    <script src="assets/js/buttons.html5.min.js"></script>
    <script src="assets/js/buttons.print.min.js"></script>
    <script src="assets/js/buttons.colVis.min.js"></script>
    <script src="assets/js/dataTables.select.min.js"></script>
    <script src="assets/js/ace-elements.min.js"></script>
    <script src="assets/js/ace.min.js"></script>
    <script src="assets/js/dataTables.fixedHeader.min.js"></script>
    <script src="assets/js/jquery.mark.min.js"></script>
    <script src="assets/js/datatables.mark.js"></script>
    <script src="assets/js/dataTables.colReorder.min.js"></script>--%>

    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            jQuery(function ($) {
                var DataTableLength = $('#ctl00_ContentPlaceHolder1_grdPost').length;
                if (DataTableLength > 0) {
                    var outerHTML = $('#ctl00_ContentPlaceHolder1_grdPost')[0].outerText;
                    if (outerHTML !== "No Records Found") {
                        //initiate dataTables plugin
                        var myTable =
                            $('#ctl00_ContentPlaceHolder1_grdPost')
                                //.wrap("<div class='dataTables_borderWrap' />")   //if you are applying horizontal scrolling (sScrollX)
                                .DataTable({
                                    mark: true,
                                    colReorder: true,
                                    fixedHeader: {
                                        header: true,
                                        footer: false
                                    },
                                    bAutoWidth: false,
                                    "aoColumns": [
                                        null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                                    ],
                                    "aaSorting": [],
                                    //"bProcessing": true,
                                    //"bServerSide": true,
                                    //"sAjaxSource": "http://127.0.0.1/table.php"	,

                                    //,
                                    //"sScrollY": "200px",
                                    //"bPaginate": false,
                                    //"sScrollX": "100%",
                                    //"sScrollXInner": "120%",
                                    //"bScrollCollapse": true,
                                    //Note: if you are applying horizontal scrolling (sScrollX) on a ".table-bordered"
                                    //you may want to wrap the table inside a "div.dataTables_borderWrap" element

                                    "iDisplayLength": 100,
                                    select: {
                                        style: 'multi'
                                    }
                                });
                        $.fn.dataTable.Buttons.defaults.dom.container.className = 'dt-buttons btn-overlap btn-group btn-overlap';
                        new $.fn.dataTable.Buttons(myTable, {
                            buttons: [
                                {
                                    "extend": "colvis",
                                    "text": "<i class='fa fa-search bigger-110 blue'></i> <span class='hidden'>Show/hide columns</span>",
                                    "className": "btn btn-white btn-primary btn-bold",
                                    columns: ':not(:first):not(:last)'
                                },
                                {
                                    "extend": "copy",
                                    "text": "<i class='fa fa-copy bigger-110 pink'></i> <span class='hidden'>Copy to clipboard</span>",
                                    "className": "btn btn-white btn-primary btn-bold"
                                },
                                {
                                    "extend": "csv",
                                    "text": "<i class='fa fa-database bigger-110 orange'></i> <span class='hidden'>Export to CSV</span>",
                                    "className": "btn btn-white btn-primary btn-bold"
                                },
                                {
                                    "extend": "excel",
                                    "text": "<i class='fa fa-file-excel-o bigger-110 green'></i> <span class='hidden'>Export to Excel</span>",
                                    "className": "btn btn-white btn-primary btn-bold"
                                },
                                {
                                    "extend": "pdf",
                                    "text": "<i class='fa fa-file-pdf-o bigger-110 red'></i> <span class='hidden'>Export to PDF</span>",
                                    "className": "btn btn-white btn-primary btn-bold"
                                },
                                {
                                    "extend": "print",
                                    "text": "<i class='fa fa-print bigger-110 grey'></i> <span class='hidden'>Print</span>",
                                    "className": "btn btn-white btn-primary btn-bold",
                                    autoPrint: true,
                                    message: 'This print was produced using the Print button for DataTables',
                                    exportOptions: {
                                        columns: ':visible'
                                    }
                                }
                            ]
                        });
                        myTable.buttons().container().appendTo($('.tableTools-container'));

                        //style the message box
                        var defaultCopyAction = myTable.button(1).action();
                        myTable.button(1).action(function (e, dt, button, config) {
                            defaultCopyAction(e, dt, button, config);
                            $('.dt-button-info').addClass('gritter-item-wrapper gritter-info gritter-center white');
                        });
                        var defaultColvisAction = myTable.button(0).action();
                        myTable.button(0).action(function (e, dt, button, config) {

                            defaultColvisAction(e, dt, button, config);
                            if ($('.dt-button-collection > .dropdown-menu').length == 0) {
                                $('.dt-button-collection')
                                    .wrapInner('<ul class="dropdown-menu dropdown-light dropdown-caret dropdown-caret" />')
                                    .find('a').attr('href', '#').wrap("<li />")
                            }
                            $('.dt-button-collection').appendTo('.tableTools-container .dt-buttons')
                        });
                        ////
                        setTimeout(function () {
                            $($('.tableTools-container')).find('a.dt-button').each(function () {
                                var div = $(this).find(' > div').first();
                                if (div.length == 1) div.tooltip({ container: 'body', title: div.parent().text() });
                                else $(this).tooltip({ container: 'body', title: $(this).text() });
                            });
                        }, 500);

                        $(document).on('click', '#ctl00_ContentPlaceHolder1_grdPost .dropdown-toggle', function (e) {
                            e.stopImmediatePropagation();
                            e.stopPropagation();
                            //e.preventDefault();
                        });
                        //And for the first simple table, which doesn't have TableTools or dataTables
                        //select/deselect all rows according to table header checkbox
                        var active_class = 'active';
                        /********************************/
                        //add tooltip for small view action buttons in dropdown menu
                        $('[data-rel="tooltip"]').tooltip({ placement: tooltip_placement });

                        //tooltip placement on right or left
                        function tooltip_placement(context, source) {
                            var $source = $(source);
                            var $parent = $source.closest('table')
                            var off1 = $parent.offset();
                            var w1 = $parent.width();

                            var off2 = $source.offset();
                            //var w2 = $source.width();

                            if (parseInt(off2.left) < parseInt(off1.left) + parseInt(w1 / 2)) return 'right';
                            return 'left';
                        }
                        /***************/
                        $('.show-details-btn').on('click', function (e) {
                            e.preventDefault();
                            $(this).closest('tr').next().toggleClass('open');
                            $(this).find(ace.vars['.icon']).toggleClass('fa-angle-double-down').toggleClass('fa-angle-double-up');
                        });
                    }
                }
            })
        });

    </script>

    <script>
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            jQuery(function ($) {
                $('.modalBackground1').click(function () {
                    var id = $(this).attr('id').replace('_backgroundElement', '');
                    $find(id).hide();
                });
            })
        });

        function fillBody(obj) {
            //debugger;
            document.getElementById('previewBody').innerHTML = obj.parentNode.childNodes[3].value;
        }
    </script>
</asp:Content>

