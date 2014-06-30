var onGetTweetsButtonClick = function () {
    var twitterAccount = document.getElementById('twitter-account-input').value;
    var outputContainer = 'public-tweets';
    TwitterApp.getPublicTweets(twitterAccount, outputContainer);
};

window.addEventListener('load', function () {
    document.getElementById('btn-get-tweets').addEventListener('click', onGetTweetsButtonClick);
});

