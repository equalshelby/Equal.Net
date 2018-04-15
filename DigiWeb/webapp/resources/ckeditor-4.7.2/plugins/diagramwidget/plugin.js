CKEDITOR.plugins.add('diagramwidget', {
    requires: 'widget',
    icons: "diagramwidget",
    init: function (editor) {
        CKEDITOR.dialog.add('diagramwidget', this.path + 'dialogs/diagramwidget.js');

        editor.widgets.add('diagramwidget',
            {
                allowedContent: 'iframe[diagramId]',
                requiredContent: 'iframe[diagramId]',
                template: '<iframe class="diagram" diagramId="" style="width:100%;height:705px;" frameborder="0" scrolling="yes"></iframe>',
                button: '添加图',
                dialog: 'diagramwidget',
                upcast: function (element) {
                    return element.name == 'iframe' && element.hasClass('diagram');
                },
                init: function () {
                    //$.print(this.element);
                    this.setData('diagramId', this.element.getAttribute("diagramId"));
                },
                data: function () {
                    this.element.setAttribute('diagramId', this.data.diagramId);
                    //无法自动刷新iframe内容
                    this.element.setAttribute('src', "/pages/diagram/diagram-detail.aspx?id=" + this.data.diagramId + "&r=" + Math.random());
                },
                mask: true
            });
    }
});


