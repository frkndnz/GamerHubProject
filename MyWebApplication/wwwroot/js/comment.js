function submitComment(event) {
    event.preventDefault();
    console.log("submitComment çalıştı.");
    var formdata = new FormData(document.getElementById('commentForm'));

    fetch('/Comment/AddComment', {
        method: 'POST',
        body: formdata
    })
        .then(response => {
            if (response.ok) {
                loadComment(formdata.get('GameId'));

            }
            else if (response.status === 401) {
                console.log("yakalandı!");
                alert("Giriş yapmanız gerekiyor!");
                window.location.href = '/Account/Login';
            }
            else {
                return Promise.reject("Yorum ekleme başarısız.");
            }
        })
        .catch(error => console.error('Hata:', error));
};

function loadComment(gameId) {

    fetch(`/Comment/LoadComments?gameId=${gameId}`)
        .then(response => response.text())
        .then(html => {
            document.getElementById('comments-list').innerHTML = html; // Yorum listesini güncelle
        })
        .catch(error => console.error('Hata:', error));
}