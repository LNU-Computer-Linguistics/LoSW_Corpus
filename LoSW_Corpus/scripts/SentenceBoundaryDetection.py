import spacy
import pysbd

models = {}

def get_doc_text(text, language):
    if language not in models:
        models[language] = spacy.blank(language)
    npl = models[language]
    doc = npl(text)
    return doc


def pysbd_segmenter(file_path, language):
    text = ""
    with open(file_path, 'r', encoding='utf-8') as file:
        text = file.read()

    seg = pysbd.Segmenter(language=language, clean=False)
    return seg.segment(text)

def spacy_sentencizer(file_path, language, punct_chars):
    nlp_sentencizer = spacy.blank(language)

    text = ""
    with open(file_path, 'r', encoding='utf-8') as file:
        text = file.read()

    # Should not be an issue, as we do not perform a complicated nlp
    nlp_sentencizer.max_length = len(text)

    sentencizer = nlp_sentencizer.add_pipe("sentencizer")
    sentencizer.punct_chars = punct_chars

    doc_sentencizer = nlp_sentencizer(text)
    return doc_sentencizer.sents
