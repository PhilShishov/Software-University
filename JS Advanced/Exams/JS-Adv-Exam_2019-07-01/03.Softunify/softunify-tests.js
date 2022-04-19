const SoftUniFy = require('./softunify');

const assert = require('chai').assert;

describe('softunify Tests', function () {
    let softunify;

    beforeEach(function () {
        softunify = new SoftUniFy();
    });

    it('should contain allSongs property that is initialized as an empty object', function () {
        // const expected = 0;
        // const actual = Object.keys(softunify.allSongs).length;

        // assert.equal(actual, expected);
        assert.deepEqual(softunify.allSongs, {});
    });

    it('downloadSong should add the given information to the allSongs in the correct format', function () {
        softunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');

        const expected = 'Venom - Knock, Knock let the devil in...';
        const actual = softunify.songsList;

        assert.equal(actual, expected);
    });

    it('playSong should return the correct string when songsList is empty or the song is not found', function () {
        const expected = `You have not downloaded a Venom song yet. Use SoftUniFy's function downloadSong() to change that!`;
        const actual = softunify.playSong('Venom');

        assert.equal(actual, expected);
    });

    it('playSong should return all songs if the song is found', function () {
        softunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');

        const expected = 'Eminem:\nVenom - Knock, Knock let the devil in...\n';
        const actual = softunify.playSong('Venom');

        assert.equal(actual, expected);
    });

    it('songsList should return the correct string when it is empty', function () {
        const expected = 'Your song list is empty';
        const actual = softunify.songsList;

        assert.equal(actual, expected);
    });

    it('songsList should return all songs when it is not empty', function () {
        softunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
        softunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');

        const expected = 'Venom - Knock, Knock let the devil in...\nPhenomenal - IM PHENOMENAL...';
        const actual = softunify.songsList;

        assert.equal(actual, expected);
    });

    it('rateArtist should return the correct string when artist is not found', function () {
        const expected = 'The Eminem is not on your artist list.';
        const actual = softunify.rateArtist('Eminem');

        assert.equal(actual, expected);
    });

    it('rateArtist should return 0 when the second argument is NaN', function () {
        softunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');

        const expected = 0;
        const actual = softunify.rateArtist('Eminem', []);

        assert.equal(actual, expected);
    });

    it('rateArtist should calculate the rate of the artist correctly', function () {
        softunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');

        const expected = 50;
        const actual = softunify.rateArtist('Eminem', 50);

        assert.equal(actual, expected);
    });
});