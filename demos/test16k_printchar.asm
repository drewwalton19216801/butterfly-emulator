    .org $bfff

main:
    jsr deadbeef
    jsr space
    jsr badfood
    jsr space
    jmp main

badfood:
    lda #$42
    jsr printchar
    lda #$41
    jsr printchar
    lda #$44
    jsr printchar
    lda #$46
    jsr printchar
    lda #$4F
    jsr printchar
    lda #$4F
    jsr printchar
    lda #$44
    jsr printchar
    rts

deadbeef:
    lda #$44
    jsr printchar
    lda #$45
    jsr printchar
    lda #$41
    jsr printchar
    lda #$44
    jsr printchar
    lda #$42
    jsr printchar
    lda #$45
    jsr printchar
    lda #$45
    jsr printchar
    lda #$46
    jsr printchar
    rts

space:
    lda #$20
    jsr printchar
    rts

printchar:
    tax
    stx $8100
    rts

    .org $fffc
    .word main
    .word $0000