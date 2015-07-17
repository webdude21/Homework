function solve() {
    return (function () {
        var item,
            book,
            media,
            validator,
            catalog,
            bookCatalog,
            mediaCatalog,
            itemType = ['id', 'name', 'description'],
            bookType = itemType.concat(['isbn']),
            mediaType = itemType.concat(['duration', 'rating']);

        validator = {
            validateIfUndefined: function (val, name) {
                name = name || 'Value';
                if (val === undefined) {
                    throw new Error(name + ' can not be undefined!')
                }
            },
            validateIfNumber: function (val, name) {
                name = name || 'Value';
                if (!validator.isNumber(val)) {
                    throw new Error(name + ' must be a number!')
                }
            },
            isNumber: function (value) {
                validator.validateIfUndefined(value);
                return !isNaN(parseFloat(value)) && isFinite(value);
            },
            validateIfPositiveNumber: function (val, name) {
                name = name || 'Value';
                validator.validateIfNumber(val, name);
                if (val <= 0) {
                    throw new Error(name + ' a positive number!')
                }
            },
            validateString: function (val, propName) {
                if (typeof val !== 'string' || !val.length) {
                    throw new Error(propName + ' must be a non empty string!')
                }
            },
            validateName: function (val) {
                validator.validateStringLength(val, 2, 40, 'name');
            },
            validateStringLength: function (val, minLength, maxLength, propName) {
                validator.validateString(val, propName);
                if (val.length < minLength || val.length > maxLength) {
                    throw new Error(propName + ' must be between ' + maxLength +
                        ' and ' + minLength + ' symbols!');
                }
            },
            validateIsbn: function (val) {
                var propName = 'isbn';
                validator.validateString(val);
                if (!(val.length === 10 || val.length === 13)) {
                    throw new Error(propName + ' must be either 10 or 13 symbols');
                }

                if (!(/^\d+$/.test(val))) {
                    throw new Error(propName + ' should contain only digits');
                }
            },
            validateGenre: function (val) {
                validator.validateStringLength(val, 2, 20, 'genre');
            },
            validateRating: function (val) {
                validator.validateIfNumber(val);
                if (val < 1 || val > 5) {
                    throw new Error('Value must be between 1 & 5 !')
                }

            },
            validateCatalogArray: function (arr, itemTypeChecker) {
                if (!arr || !arr.length) {
                    throw new Error('No items passed!');
                }

                arr.forEach(itemTypeChecker)
            },
            checkIfHasKeys: function (item, keys) {
                keys.forEach(function (key) {
                    validator.validateIfUndefined(item[key])
                });
            },
            checkIfItem: function (item) {
                validator.checkIfHasKeys(item, itemType);
            },
            checkIfBook: function (book) {
                validator.checkIfHasKeys(book, bookType);
            },
            checkIfMedia: function (media) {
                validator.checkIfHasKeys(media, mediaType);
            }
        };

        item = (function () {
            var currentItemId = 0,
                item = Object.create({});
            Object.defineProperties(item, {
                init: {
                    value: function (name, description) {
                        this.name = name;
                        this.description = description;
                        this._id = currentItemId += 1;
                        return this;
                    }
                },
                id: {
                    get: function () {
                        return this._id;
                    }
                },
                description: {
                    get: function () {
                        return this._description;
                    },
                    set: function (value) {
                        validator.validateString(value, 'description');
                        this._description = value;
                    }
                },
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        validator.validateName(value);
                        this._name = value;
                    }
                }
            });

            return item;
        }());

        book = (function (parent) {
            var book = Object.create(parent);
            Object.defineProperties(book, {
                init: {
                    value: function (name, isbn, genre, description) {
                        parent.init.call(this, name, description);
                        this.isbn = isbn;
                        this.genre = genre;
                        return this;
                    }
                },
                isbn: {
                    get: function () {
                        return this._isbn;
                    },
                    set: function (value) {
                        validator.validateIsbn(value);
                        this._isbn = value;
                    }
                },
                genre: {
                    get: function () {
                        return this._genre;
                    },
                    set: function (value) {
                        validator.validateGenre(value);
                        this._genre = value;
                    }
                }
            });

            return book;
        }(item));

        media = (function (parent) {
            var media = Object.create(parent);
            Object.defineProperties(media, {
                init: {
                    value: function (name, rating, duration, description) {
                        parent.init.call(this, name, description);
                        this.duration = duration;
                        this.rating = rating;
                        return this;
                    }
                },
                rating: {
                    get: function () {
                        return this._rating;
                    },
                    set: function (value) {
                        validator.validateRating(value);
                        this._rating = value;
                    }
                },
                duration: {
                    get: function () {
                        return this._duration;
                    },
                    set: function (value) {
                        validator.validateIfPositiveNumber(value, 'duration');
                        this._duration = value;
                    }
                }
            });

            return media;
        }(item));

        catalog = (function () {
            var currentItemId = 0,
                catalog = Object.create({});

            Object.defineProperties(catalog, {
                init: {
                    value: function (name) {
                        this.name = name;
                        this._id = currentItemId += 1;
                        this._items = [];
                        this._typeChecker = validator.checkIfItem;
                        this._findFilter = function (item, options) {
                            return Object.keys(options).every(function (key) {
                                return options[key] && item[key] ? options[key] === item[key] : true;
                            });
                        };
                        this._search = function (item, pattern) {
                            var regexPattern = new RegExp(pattern, 'gi');
                            return item.name.match(regexPattern) || item.description.match(regexPattern)
                        };
                        return this;
                    }
                },
                id: {
                    get: function () {
                        return this._id;
                    }
                },
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        validator.validateName(value);
                        this._name = value;
                    }
                },
                items: {
                    get: function () {
                        return this._items;
                    }
                },
                add: {
                    value: function (array) {
                        var args;

                        if (Array.isArray(array)) {
                            args = array;
                        } else {
                            args = Array.prototype.slice.call(arguments);
                        }

                        validator.validateCatalogArray(args, this._typeChecker);

                        this._items = this._items.concat(args);
                        return this;
                    }
                },
                find: {
                    value: function (params) {
                        var id,
                            filteredResult;

                        if (typeof params === 'object') {
                            return this._items.filter(function (item) {
                                return this._findFilter(item, params);
                            }, this);
                        } else {
                            id = params;
                            validator.validateIfNumber(id);

                            filteredResult = this._items.filter(function (item) {
                                return item.id === id;
                            });

                            if (filteredResult[0]) {
                                return filteredResult[0]
                            } else {
                                return null;
                            }
                        }
                    }
                },
                search: {
                    value: function (pattern) {
                        validator.validateString(pattern, 'pattern');

                        return this._items.filter(function (item) {
                            return this._search(item, pattern);
                        }, this);
                    }
                }
            });

            return catalog;
        }());

        bookCatalog = (function (parent) {
            var bookCatalog = Object.create(parent);

            Object.defineProperties(bookCatalog, {
                init: {
                    value: function (name) {
                        parent.init.call(this, name);
                        this._typeChecker = validator.checkIfBook;
                        return this;
                    }
                },
                getGenres: {
                    value: function () {
                        var result = [],
                            currentItem;

                        this._items.forEach(function (item) {
                            currentItem = item.genre.toLowerCase();
                            if (result.indexOf(currentItem) === -1) {
                                result.push(currentItem);
                            }
                        });

                        return result;
                    }
                }
            });

            return bookCatalog;
        }(catalog));

        mediaCatalog = (function (parent) {
            var mediaCatalog = Object.create(parent);

            Object.defineProperties(mediaCatalog, {
                init: {
                    value: function (name) {
                        parent.init.call(this, name);
                        this._typeChecker = validator.checkIfMedia;
                        return this;
                    }
                },
                getTop: {
                    value: function (count) {
                        validator.validateIfPositiveNumber(count, 'count');
                        if (count < 1) {
                            throw new Error('Count should be greater or equal to 1');
                        }

                        return this.items
                            .sort(function (a, b) {
                                return a.rating - b.rating
                            })
                            .map(function (item) {
                                return {
                                    id: item.id,
                                    name: item.name
                                }
                            })
                            .slice(0, count);
                    }
                },
                getSortedByDuration: {
                    value: function () {
                        return this.items.sort(function (a, b) {
                            return b.duration - a.duration || a.id - b.id;
                        });
                    }
                }
            });

            return mediaCatalog;
        }(catalog));

        return {
            getBook: function (name, isbn, genre, description) {
                return Object.create(book).init(name, isbn, genre, description);
            },
            getMedia: function (name, rating, duration, description) {
                return Object.create(media).init(name, rating, duration, description);
            },
            getBookCatalog: function (name) {
                return Object.create(bookCatalog).init(name);
            },
            getMediaCatalog: function (name) {
                return Object.create(mediaCatalog).init(name);
            }
        };
    }());
}

var module = solve();
var catalog = module.getBookCatalog('John\'s catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
catalog.add(book1);
catalog.add(book2);

console.log(catalog.find(book1.id));
//returns book1

console.log(catalog.find({id: book2.id, genre: 'IT'}));
//returns book2

console.log(catalog.search('js'));
// returns book2

console.log(catalog.search('javascript'));
//returns book1 and book2

console.log(catalog.search('Te sa zeleni'));
//returns []
