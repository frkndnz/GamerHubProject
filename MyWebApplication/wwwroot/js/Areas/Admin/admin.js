function deleteGame(gameId) {
    if (confirm("Oyunu silmek istediğinizden emin misiniz ?")) {

        fetch(`/Admin/Game/Delete/${gameId}`
            , { method: "DELETE" }
        )
            .then(
                Response => {
                    if (Response.ok) {
                        alert('Oyun başarıyla silindi !');
                        window.location.reload();
                    }
                    else {
                        alert('Bir hata oluştu !');
                    }
                }
            )
            .catch(error => {
                console.error('Hata', error);
                alert('Sunucuyla baglantı kurulamıyor!');
            });
    }
    else {
        alert("Silme işlemi iptal edildi !");
    }
}