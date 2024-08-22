     
// Hàm xử lý xóa ảnh
function deleteSelectedImage() {
    // Lấy đường dẫn của ảnh được chọn
    var selectedImage = getSelectedImage();
    
    // Gửi yêu cầu xóa ảnh
    deleteImage(selectedImage);
}

// Hàm lấy đường dẫn của ảnh được chọn
function getSelectedImage() {
    var selection = window.getSelection();
    if (selection.rangeCount > 0) {
        var range = selection.getRangeAt(0);
        var img = range.startContainer.nodeName === 'IMG' ? range.startContainer : null;
        if (img) {
            return img.src;
        }
    }
    return null;
}

// Hàm gửi yêu cầu xóa ảnh đến máy chủ
function deleteImage(imageSrc) {
  
    $.ajax({
        method:"post",
        url:'?quanly=post&action=delete',
        data:{src :imageSrc}
        
    })
    .done(function (data) {
       alert("ok")
   
      
    })
    .fail(function (data) {
        alert("lỗi")
    })


}


CKEDITOR.replace('noidung',{
    width: "700px",
    height: "400px",
    filebrowserUploadMethod:"form",
    filebrowserUploadUrl:"?quanly=post&action=upload",
    on: {
        // Sự kiện xóa hình
        instanceReady: function (ev) {
          ev.editor.on('contentDom', function () {
            // Bắt sự kiện xóa ảnh từ CKEditor
            this.document.on('keydown', function (event) {
              if (event.data.$.keyCode === 46) {
                // Gọi hàm xóa ảnh khi người dùng nhấn phím Delete
                alert("ok");
                deleteSelectedImage();
              }
            });
          });
        }
    }
    }
    );