class Emotion {
    constructor(input, emotions) {
        if (typeof input !== 'string') throw new Error("input must be String");
        if (!Array.isArray(emotions)) throw new Error("emotions must be Array");

        this.Input = input;
        this.Emotions = emotions;
    }

    static isEmotion(sample) {
        try {
            if (!sample || typeof sample.Input === 'undefined'
                || typeof sample.Emotions === 'undefined')
                return false;

            const input = sample.Input;
            const emotions = sample.Emotions;

            if (typeof input !== 'string') return false;
            if (!Array.isArray(emotions)) return false;

            return true;
        } catch {
            return false;
        }
    }
}

class Format {
    constructor(input, emotions, format) {
        if (typeof input !== 'string') throw new Error("input must be String");
        if (!Array.isArray(emotions)) throw new Error("emotions must be Array");
        if (typeof format !== 'string') throw new Error("format must be String");

        this.Input = input;
        this.Emotions = emotions;
        this.Format = format;
    }

    static isFormat(sample) {
        try {
            if (!sample || typeof sample.Input === 'undefined'
                || typeof sample.Emotions === 'undefined'
                || typeof sample.Format === 'undefined')
                return false;

            const input = sample.Input;
            const emotions = sample.Emotions;
            const format = sample.Format;

            if (typeof input !== 'string') return false;
            if (!Array.isArray(emotions)) return false;
            if (typeof format !== 'string') return false;

            return true;
        } catch {
            return false;
        }
    }
}

class Information {
    constructor(intends, purposes, informations) {
        if (!Array.isArray(intends)) throw new Error("intends must be Array");
        if (!Array.isArray(purposes)) throw new Error("purposes must be Array");
        if (!Array.isArray(informations)) throw new Error("informations must be Array");

        this.Intends = intends;
        this.Purposes = purposes;
        this.Informations = informations;
    }

    static isInformation(sample) {
        try {
            if (!sample || typeof sample.Intends === 'undefined'
                || typeof sample.Purposes === 'undefined'
                || typeof sample.Informations === 'undefined')
                return false;

            const intends = sample.Intends;
            const purposes = sample.Purposes;
            const informations = sample.Informations;

            if (!Array.isArray(intends)) return false;
            if (!Array.isArray(purposes)) return false;
            if (!Array.isArray(informations)) return false;

            return true;
        } catch {
            return false;
        }
    }
}

class Intend {
    constructor(input, intends) {
        if (typeof input !== 'string') throw new Error("input must be String");
        if (!Array.isArray(intends)) throw new Error("intends must be Array");

        this.Input = input;
        this.Intends = intends;
    }

    static isIntend(sample) {
        try {
            if (!sample || typeof sample.Input === 'undefined'
                || typeof sample.Intends === 'undefined')
                return false;

            const input = sample.Input;
            const intends = sample.Intends;

            if (typeof input !== 'string') return false;
            if (!Array.isArray(intends)) return false;

            return true;
        } catch {
            return false;
        }
    }
}

class Output {
    constructor(format, emotions, informations, output) {
        if (typeof format !== 'string') throw new Error("format must be String");
        if (!Array.isArray(emotions)) throw new Error("emotions must be Array");
        if (!Array.isArray(informations)) throw new Error("informations must be Array");
        if (typeof output !== 'string') throw new Error("output must be String");

        this.Format = format;
        this.Emotions = emotions;
        this.Informations = informations;
        this.Output = output;
    }

    static isOutput(sample) {
        try {
            if (!sample || typeof sample.Format === 'undefined'
                || typeof sample.Emotions === 'undefined' || typeof sample.Informations === 'undefined'
                || typeof sample.Output === 'undefined')
                return false;

            const format = sample.Format;
            const emotions = sample.Emotions;
            const informations = sample.Informations;
            const output = sample.Output;

            if (typeof format !== 'string') return false;
            if (!Array.isArray(emotions)) return false;
            if (!Array.isArray(informations)) return false;
            if (typeof output !== 'string') return false;

            return true;
        } catch {
            return false;
        }
    }
}

class Purpose {
    constructor(input, purposes) {
        if (typeof input !== 'string') throw new Error("input must be String");
        if (!Array.isArray(purposes)) throw new Error("purposes must be Array");

        this.Input = input;
        this.Purposes = purposes;
    }

    static isPurpose(sample) {
        try {
            if (!sample || typeof sample.Input === 'undefined'
                || typeof sample.Purposes === 'undefined')
                return false;

            const input = sample.Input;
            const purposes = sample.Purposes;

            if (typeof input !== 'string') return false;
            if (!Array.isArray(purposes)) return false;

            return true;
        } catch {
            return false;
        }
    }
}

class CompleteConversation {
    constructor(input, output, format, intends, purposes, emotions, informations) {
        if (typeof input !== 'string') throw new Error("input must be String");
        if (typeof output !== 'string') throw new Error("output must be String");
        if (typeof format !== 'string') throw new Error("format must be String");
        if (!Array.isArray(intends)) throw new Error("intends must be Array");
        if (!Array.isArray(purposes)) throw new Error("purposes must be Array");
        if (!Array.isArray(emotions)) throw new Error("emotions must be Array");
        if (!Array.isArray(informations)) throw new Error("informations must be Array");

        this.Input = input;
        this.Output = output;
        this.Format = format;
        this.Intends = intends;
        this.Purposes = purposes;
        this.Emotions = emotions;
        this.Informations = informations;
    }

    static isCompleteConversation(sample) {
        try {
            if (!sample || typeof sample.Input === 'undefined' || typeof sample.Output === 'undefined' ||
                typeof sample.Format === 'undefined' || typeof sample.Intends === 'undefined' ||
                typeof sample.Purposes === 'undefined' || typeof sample.Emotions === 'undefined' ||
                sample.Informations === 'undefined') return false;

            const input = sample.Input;
            const output = sample.Output;
            const format = sample.Format;
            const intends = sample.Intends;
            const purposes = sample.Purposes;
            const emotions = sample.Emotions;
            const informations = sample.Informations;

            if (typeof input !== 'string') return false;
            if (typeof output !== 'string') return false;
            if (typeof format !== 'string') return false;
            if (!Array.isArray(intends)) return false;
            if (!Array.isArray(purposes)) return false;
            if (!Array.isArray(emotions)) return false;
            if (!Array.isArray(informations)) return false;

            return true;
        } catch {
            return false;
        }
    }
}



class Models {
    #value;
    constructor(value) {
        if (new.target !== Models)
            throw new Error("Models must be created with inner methods");
        this.#value = Number(value);
    }
    get value() {
        return this.#value;
    }

    static All = new Models(0);
    static EmotionsDetector = new Models(1);
    static FormatProvider = new Models(2);
    static IntendIdentifier = new Models(3);
    static PurposeIdentifier = new Models(4);
    static InformationProvider = new Models(5);
    static OutputGenerator = new Models(6);
    static Texts = ["All", "EmotionsDetector", "FormatProvider",
        "IntendIdentifier", "PurposeIdentifier",
        "InformationProvider", "OutputGenerator"];
    static FromText(text) {
        if (text === "All") return Models.All;
        if (text === "EmotionsDetector") return Models.EmotionsDetector;
        if (text === "FormatProvider") return Models.FormatProvider;
        if (text === "IntendIdentifier") return Models.IntendIdentifier;
        if (text === "PurposeIdentifier") return Models.PurposeIdentifier;
        if (text === "InformationProvider") return Models.InformationProvider;
        if (text === "OutputGenerator") return Models.OutputGenerator;

        throw new Error("text must be one of the Models.Texts");
    }
    

    static isModel(sample) {
        if (!(sample instanceof Models)) return false;
        if (sample.value > 6 || sample.value < 0) return false;

        return true;
    }
}
class DatabaseRequest {
    constructor(skip, top, ignored, loaded, model) {
        if (typeof skip !== 'number') throw new Error("skip must be Number");
        if (typeof top !== 'number') throw new Error("top must be Number");
        if (!Models.isModel(model)) throw new Error("model must be Models");
        if (typeof ignored !== 'boolean') throw new Error("ignored must be Array");
        if (typeof loaded !== 'boolean') throw new Error("ignored must be Array");

        this.Skip = skip;
        this.Top = top;
        this.Model = model;
        this.Ignored = ignored;
        this.Loaded = loaded;
    }
    async getResponse() {
        try {
            const url = `${BaseUrl}/Database/GetTrainingData${makeUrlParams(this.Skip, this.Top, this.Ignored, this.Loaded, this.Model.value)}`;
            console.log(url);
            const response = await fetch(url, {
                method: "GET",
                headers: {
                    "Accept": "application/json",
                    "Cache-Control": "no-cache"
                }
            });

            if (!response.ok) {
                console.error("Error: ", response.statusText);
            }
            const data = await response.json();
            console.log(data);
            return data;
        } catch (error) {
            console.error("Error: ", error);
        }
    }
}