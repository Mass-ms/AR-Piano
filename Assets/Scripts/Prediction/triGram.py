from collections import defaultdict
from pychord import Chord
import re
import os
import sys

# ファイルからコード進行を読み込む関数
def load_chord_progressions(file_path):
    progressions = []
    with open(file_path, 'r',encoding='utf-8') as file:
        for line in file:
            # `#` から始まる行はスキップする
            if line.strip().startswith("#"):
                continue
            progression = re.split(r'\s+', line.strip())
            progressions.append(progression)
    return progressions

# 3-Gramモデルを構築する関数
def build_trigram_model(progressions):
    trigrams = defaultdict(lambda: defaultdict(int))  # 3-Gramの確率を格納する辞書
    
    for progression in progressions:
        for i in range(len(progression) - 2):
            # 連続する3つのコードを取得
            trigram = tuple(progression[i:i+3])
            # 前の2つのコードをコンテキストとする
            context = trigram[:-1]
            # 次のコードをターゲットとする
            target = trigram[-1]
            # 3-Gramの出現回数をカウント
            trigrams[context][target] += 1
    
    # 出現回数から確率を計算する
    trigram_probabilities = {}
    for context, target_counts in trigrams.items():
        total_count = sum(target_counts.values())
        probabilities = {target: count / total_count
                         for target, count in target_counts.items()}
        trigram_probabilities[context] = probabilities
    
    return trigram_probabilities

# コンテキストに基づいて次のコードを予測する関数
def predict_next_chord_with_probabilities(chord1, chord2, transpose, trigram_model):
    # 与えられたシーケンスからコンテキスト（最後の2つのコード）を取得
    context = (chord1, chord2)
    # コンテキストがモデルに存在するか確認し、出現確率を取得する
    if context in trigram_model:
        probabilities = trigram_model[context]
        # コードと出現確率を確率の高い順に並べる
        sorted_probabilities = sorted(probabilities.items(), key=lambda x: x[1], reverse=True)
        # 結果のコードをトランスポーズし、コード名を取得する
        transposed_chords = {}
        for chord_name, prob in sorted_probabilities:
            chord = Chord(chord_name)
            chord.transpose(transpose)
            transposed_chords[chord.chord] = prob
        # パーセント表記で整形する
        formatted_probabilities = {
            chord: f"{int(prob * 100)}%"
            for chord, prob in transposed_chords.items()
        }
        return formatted_probabilities
    else:
        return None

file_path = os.path.dirname(os.path.realpath(__file__)) + "\\dataset\\yoasobi_chord_progressions.txt"
print(file_path)
# ファイルからコード進行を読み込む
progressions = load_chord_progressions(file_path)

# 3-Gramモデルを構築する
trigram_model = build_trigram_model(progressions)

# 構築したモデルの一部を出力する（最初の5つのコンテキスト）
# for i, (context, probabilities) in enumerate(trigram_model.items()):
#     print(f"Context: {context}, Probabilities: {probabilities}")

# 引数から予測を返す
prevChord = Chord(sys.argv[1])
currentChord = Chord(sys.argv[2])
transpose = int(sys.argv[3])
prevChord.transpose(-transpose)
currentChord.transpose(-transpose)

predicted = predict_next_chord_with_probabilities(prevChord.chord, currentChord.chord, transpose, trigram_model)
print(predicted)