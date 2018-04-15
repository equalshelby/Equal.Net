CKEDITOR.dialog.add("diagramwidget", function (editor) {
    return {
        title: '编辑图',
        minWidth: 1050,
        minHeight: 700,
        contents: [
            {
                id: "tab1",
                label: "",
                title: "",
                expand: !0,
                padding: 0,
                elements: [
                    {
                        type: "html",
                        html: "<iframe name='diagramIframe' id='diagramIframe' style='width:100%;height:705px;' frameborder='0' scrolling='yes' src='" + editor.config.diagramEditUrl + "'></iframe>",
                        setup: function (widget) {
                            diagramIframe.location.href = "/pages/diagram/diagram-edit.aspx?ckeditor=true&id=" + widget.data.diagramId;
                        },
                        commit: function (widget) {
                            var diagramId = diagramIframe.window.document.getElementById("hfId").value;
                            //alert(diagramId);
                            widget.setData('diagramId', diagramId);
                        }
                    }
                ]
            }
        ],
        onOk: function () {
            diagramIframe.window.document.getElementById("save").click();
            //diagramIframe.window.document.save();
            //return false;
        }
    };
});