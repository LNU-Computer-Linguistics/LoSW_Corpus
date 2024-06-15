import spacy
import spacy_fastlang

def init():
    global language_detection_processor
    language_detection_processor = spacy.blank("en")
    language_detection_processor.add_pipe("language_detector")

def is_init():
    return 'language_detection_processor' in globals()

"""
Only analyzes the first 100 characters.
"""
def detect_language(file_path):

    chunk = ""
    with open(file_path, 'r', encoding='utf-8') as file:
        chunk = file.read(100)
        
    if not chunk:
        raise Exception("[LanguageDetect] File seems to be empty")

    if not is_init():
        init()

    doc = language_detection_processor(chunk)

    return doc._.language